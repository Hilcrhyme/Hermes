using Hermes.Common.IdentityGenerator.Exception;

namespace Hermes.Common.IdentityGenerator
{
    /// <summary>
    /// 雪花算法 Id 生成器
    /// </summary>
    public class SnowflakeIdentityGenerator : IIdentityGenerator<long>
    {
        /// <summary>
        /// 数据中心编号
        /// </summary>
        public long DataCenterNumber { get; init; } = 0;

        /// <summary>
        /// 数据中心编号比特长度
        /// </summary>
        public byte DataCenterNumberBitLength { get; init; } = 5;

        /// <summary>
        /// 数据中心最大编号
        /// </summary>
        public long MaximumDataCenterNumber => -1 ^ (-1 << DataCenterNumberBitLength);

        /// <summary>
        /// 工作机器编号
        /// </summary>
        public long WorkerNumber { get; init; } = 0;

        /// <summary>
        /// 工作机器编号比特长度
        /// </summary>
        public byte WorkerNumberBitLength { get; init; } = 5;

        /// <summary>
        /// 工作机器最大编号
        /// </summary>
        public long MaximumWorkerNumber => -1 ^ (-1 << WorkerNumberBitLength);

        /// <summary>
        /// 序列号
        /// </summary>
        private long SerialNumber = 0;

        /// <summary>
        /// 序列号比特长度
        /// </summary>
        public byte SerialNumberBitLength { get; init; } = 12;

        /// <summary>
        /// 最大序列号
        /// </summary>
        public long MaximumSerialNumber => -1 ^ (-1 << SerialNumberBitLength);

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; init; } = DateTime.MinValue;

        /// <summary>
        /// 时间戳比特长度
        /// </summary>
        public byte TimestampBitLength { get; init; } = 41;

        /// <summary>
        /// 上次生成的时间戳
        /// </summary>
        private long LastTimestamp = 0;

        /// <summary>
        /// 工作机器编号偏移量
        /// </summary>
        public byte WorkerNumberOffset => SerialNumberBitLength;

        /// <summary>
        /// 数据中心编号偏移量
        /// </summary>
        public byte DataCenterNumberOffset => (byte)(SerialNumberBitLength + WorkerNumberBitLength);

        /// <summary>
        /// 时间戳偏移量
        /// </summary>
        public byte TimestampOffset => (byte)(SerialNumberBitLength + WorkerNumberBitLength + DataCenterNumberBitLength);

        /// <summary>
        /// 线程同步锁
        /// </summary>
        private readonly object Locker = new();

        /// <summary>
        /// 实例化雪花算法 Id 生成器
        /// </summary>
        /// <param name="dataCenterNumber">数据中心编号</param>
        /// <param name="workerNumber">工作机器编号</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public SnowflakeIdentityGenerator(long dataCenterNumber, long workerNumber) : this(new DateTime(DateTime.UtcNow.Year, 1, 1), 41, 5, 5, 12, dataCenterNumber, workerNumber)
        {
        }

        /// <summary>
        /// 实例化雪花算法 Id 生成器
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="timestampBitLength">时间戳比特长度</param>
        /// <param name="dataCenterNumberBitLength">数据中心编号比特长度</param>
        /// <param name="workerNumberBitLength">工作机器编号比特长度</param>
        /// <param name="serialNumberBitLength">序列号比特长度</param>
        /// <param name="dataCenterNumber">数据中心编号</param>
        /// <param name="workerNumber">工作机器编号</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="TotalDigitsTooLongException"></exception>
        public SnowflakeIdentityGenerator(DateTime startTime, byte timestampBitLength, byte dataCenterNumberBitLength, byte workerNumberBitLength, byte serialNumberBitLength, long dataCenterNumber, long workerNumber)
        {
            if (timestampBitLength < 0 || timestampBitLength > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(timestampBitLength));
            }
            if (dataCenterNumberBitLength < 0 || dataCenterNumberBitLength > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(dataCenterNumberBitLength));
            }
            if (workerNumberBitLength < 0 || workerNumberBitLength > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(workerNumberBitLength));
            }
            if (serialNumberBitLength < 0 || serialNumberBitLength > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(serialNumberBitLength));
            }
            if (dataCenterNumber > MaximumDataCenterNumber || dataCenterNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dataCenterNumber));
            }
            if (workerNumber > MaximumWorkerNumber || workerNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(workerNumber));
            }
            if (timestampBitLength + dataCenterNumberBitLength + workerNumberBitLength + serialNumberBitLength > 63)
            {
                throw new TotalDigitsTooLongException();
            }
            StartTime = startTime;
            TimestampBitLength = timestampBitLength;
            DataCenterNumberBitLength = dataCenterNumberBitLength;
            WorkerNumberBitLength = workerNumberBitLength;
            SerialNumberBitLength = serialNumberBitLength;
            DataCenterNumber = dataCenterNumber;
            WorkerNumber = workerNumber;
        }

        /// <summary>
        /// 异步获取 Id
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TimeRewindException"></exception>
        public ValueTask<long> GetNextIdAsync()
        {
            lock (Locker)
            {
                var timestamp = GetTimestamp();
                if (timestamp < LastTimestamp)
                {
                    throw new TimeRewindException();
                }
                if (timestamp == LastTimestamp)
                {
                    // 同一毫秒内
                    SerialNumber = (SerialNumber + 1) & MaximumSerialNumber;
                    if (SerialNumber == 0)
                    {
                        // 序列号已达上限，需等待至下一毫秒
                        while (timestamp <= LastTimestamp)
                        {
                            timestamp = GetTimestamp();
                        }
                    }
                }
                else
                {
                    // 不同毫秒内，序列号重新计算
                    SerialNumber = 0;
                }
                LastTimestamp = timestamp;
                return ValueTask.FromResult((timestamp << TimestampOffset) | (DataCenterNumber << DataCenterNumberOffset) | (WorkerNumber << WorkerNumberOffset) | SerialNumber);
            }
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        private long GetTimestamp()
        {
            return (long)(DateTime.UtcNow - StartTime).TotalMilliseconds;
        }
    }
}