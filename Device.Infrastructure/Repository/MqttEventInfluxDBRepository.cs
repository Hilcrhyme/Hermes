using Hermes.Service.Device.Domain.Aggregates.MqttEventAggregate;

using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core;

namespace Hermes.Service.Device.Infrastructure.Repository
{
    /// <summary>
    /// Mqtt 事件 InfluxDB 仓储
    /// </summary>
    /// <typeparam name="T">仓储的元素类型</typeparam>
    public class MqttEventInfluxDBRepository<T> : IMqttEventRepository<T> where T : MqttEvent
    {
        /// <summary>
        /// 数据库地址
        /// </summary>
        private readonly string url;

        /// <summary>
        /// 数据库令牌
        /// </summary>
        private readonly string token;

        /// <summary>
        /// 桶
        /// </summary>
        private readonly string bucket;

        /// <summary>
        /// 组织
        /// </summary>
        private readonly string organization;

        /// <summary>
        /// 实例化客户端已连接 Mqtt 事件仓储
        /// </summary>
        /// <param name="url">数据库地址</param>
        /// <param name="token">数据库令牌</param>
        /// <param name="bucket">桶</param>
        /// <param name="organization">组织</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttEventInfluxDBRepository(string url, string token, string bucket, string organization)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }
            if (string.IsNullOrEmpty(bucket))
            {
                throw new ArgumentNullException(nameof(bucket));
            }
            if (string.IsNullOrEmpty(organization))
            {
                throw new ArgumentNullException(nameof(organization));
            }
            this.url = url;
            this.token = token;
            this.bucket = bucket;
            this.organization = organization;
        }

        /// <summary>
        /// 异步添加 Mqtt 事件
        /// </summary>
        /// <param name="entity">Mqtt 事件</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public async Task<T> AddAsync(T entity)
        {
            using var client = new InfluxDBClient(new InfluxDBClientOptions(url)
            {
                Token = token
            });
            var writeApi = client.GetWriteApiAsync();
            if (entity is ClientConnectedMqttEvent clientConnectedMqttEvent)
            {
                await writeApi.WriteMeasurementAsync(new ClientConnectedMqttEventMapper()
                {
                    Id = clientConnectedMqttEvent.Id,
                    ClientId = clientConnectedMqttEvent.ClientId,
                    Username = clientConnectedMqttEvent.Username,
                    ConnectedAt = clientConnectedMqttEvent.ConnectedAt,
                    Timestamp = clientConnectedMqttEvent.Timestamp
                }, WritePrecision.Ms, bucket, organization);
            }
            else if (entity is ClientDisconnectedMqttEvent clientDisconnectedMqttEvent)
            {
                await writeApi.WriteMeasurementAsync(new ClientDisconnectedMqttEventMapper()
                {
                    Id = clientDisconnectedMqttEvent.Id,
                    ClientId = clientDisconnectedMqttEvent.ClientId,
                    Username = clientDisconnectedMqttEvent.Username,
                    Reason = clientDisconnectedMqttEvent.Reason,
                    DisconnectedAt = clientDisconnectedMqttEvent.DisconnectedAt,
                    Timestamp = clientDisconnectedMqttEvent.Timestamp
                });
            }
            else if (entity is MessagePublishedMqttEvent messagePublishedMqttEvent)
            {
                await writeApi.WriteMeasurementAsync(new MessagePublishedMqttEventMapper()
                {
                    Id = messagePublishedMqttEvent.Id,
                    ClientId = messagePublishedMqttEvent.ClientId,
                    Username = messagePublishedMqttEvent.Username,
                    MessageId = messagePublishedMqttEvent.MessageId,
                    Payload = messagePublishedMqttEvent.Payload,
                    Topic = messagePublishedMqttEvent.Topic,
                    QualityofService = messagePublishedMqttEvent.QualityofService,
                    RetainFlag = messagePublishedMqttEvent.RetainFlag,
                    DupFlag = messagePublishedMqttEvent.DupFlag,
                    PublishReceivedAt = messagePublishedMqttEvent.PublishReceivedAt,
                    Timestamp = messagePublishedMqttEvent.Timestamp
                });
            }
            else
            {
                throw new NotSupportedException();
            }
            return entity;
        }

        /// <summary>
        /// 异步删除 Mqtt 事件
        /// </summary>
        /// <param name="id">Mqtt 事件 Id</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public Task RemoveAsync(long id)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 异步更新 Mqtt 事件
        /// </summary>
        /// <param name="entity">Mqtt 事件</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public Task<T> UpdateAsync(T entity)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// 异步获取 Mqtt 事件
        /// </summary>
        /// <param name="id">Mqtt 事件 Id</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public async Task<T?> GetAsync(long id)
        {
            using var client = new InfluxDBClient(new InfluxDBClientOptions(url)
            {
                Token = token
            });
            var queryApi = client.GetQueryApi();
            var flux = $"from(bucket:\"{bucket}\") " +
                       $"|> range(start: {DateTime.MinValue:O}) " +
                       $"|> filter(fn: (r) => r._measurement == \"{nameof(T)}\" and r.Id == \"{id}\") " +
                       $"|> first() " +
                       $"|> yield()";
            if (typeof(T) == typeof(ClientConnectedMqttEvent))
            {
                var results = await queryApi.QueryAsync<ClientConnectedMqttEventMapper>(flux, organization);
                var mapper = results.FirstOrDefault();
                if (mapper is null)
                {
                    return null;
                }
                return new ClientConnectedMqttEvent(mapper.Id)
                {
                    ClientId = mapper.ClientId,
                    Username = mapper.Username,
                    ConnectedAt = mapper.ConnectedAt,
                    Timestamp = mapper.Timestamp
                } as T;
            }
            else if (typeof(T) == typeof(ClientDisconnectedMqttEvent))
            {
                var results = await queryApi.QueryAsync<ClientDisconnectedMqttEventMapper>(flux, organization);
                var mapper = results.FirstOrDefault();
                if (mapper is null)
                {
                    return null;
                }
                return new ClientDisconnectedMqttEvent(mapper.Id)
                {
                    ClientId = mapper.ClientId,
                    Username = mapper.Username,
                    DisconnectedAt = mapper.DisconnectedAt,
                    Reason = mapper.Reason,
                    Timestamp = mapper.Timestamp
                } as T;
            }
            else if (typeof(T) == typeof(MessagePublishedMqttEvent))
            {
                var results = await queryApi.QueryAsync<MessagePublishedMqttEventMapper>(flux, organization);
                var mapper = results.FirstOrDefault();
                if (mapper is null)
                {
                    return null;
                }
                return new MessagePublishedMqttEvent(mapper.Id)
                {
                    ClientId = mapper.ClientId,
                    Username = mapper.Username,
                    MessageId = mapper.MessageId,
                    Payload = mapper.Payload,
                    Topic = mapper.Topic,
                    QualityofService = mapper.QualityofService,
                    RetainFlag = mapper.RetainFlag,
                    DupFlag = mapper.DupFlag,
                    PublishReceivedAt = mapper.PublishReceivedAt,
                    Timestamp = mapper.Timestamp
                } as T;
            }
            else
            {
                throw new NotSupportedException(); 
            }
        }

        /// <summary>
        /// 异步获取 Mqtt 事件只读集合
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyCollection<T>> GetCollectionAsync()
        {
            return GetCollectionAsync(DateTime.MinValue, DateTime.MaxValue, int.MaxValue);
        }

        /// <summary>
        /// 异步获取 Mqtt 事件只读集合
        /// </summary>
        /// <param name="count">只读集合元素总数</param>
        /// <returns></returns>
        public Task<IReadOnlyCollection<T>> GetCollectionAsync(int count)
        {
            return GetCollectionAsync(DateTime.MinValue, DateTime.MaxValue, count);
        }

        /// <summary>
        /// 异步获取 Mqtt 事件只读集合
        /// </summary>
        /// <param name="start">查询的时间范围的起始时间</param>
        /// <param name="stop">查询的时间范围的结束时间</param>
        /// <returns></returns>
        public Task<IReadOnlyCollection<T>> GetCollectionAsync(DateTime start, DateTime stop)
        {
            return GetCollectionAsync(start, stop, int.MaxValue);
        }

        /// <summary>
        /// 异步获取 Mqtt 事件只读集合
        /// </summary>
        /// <param name="start">查询的时间范围的起始时间</param>
        /// <param name="stop">查询的时间范围的结束时间</param>
        /// <param name="count">只读集合元素总数</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public async Task<IReadOnlyCollection<T>> GetCollectionAsync(DateTime start, DateTime stop, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            using var client = new InfluxDBClient(new InfluxDBClientOptions(url)
            {
                Token = token
            });
            var queryApi = client.GetQueryApi();
            var flux = $"from(bucket:\"{bucket}\") " +
                       $"|> range(start: {start:O}, stop: {stop:O}) " +
                       $"|> filter(fn: (r) => r._measurement == \"{nameof(T)}\") " +
                       $"|> limit(n:{count}) " +
                       $"|> yield()";
            
            if (typeof(T) == typeof(ClientConnectedMqttEvent))
            {
                var results = await queryApi.QueryAsync<ClientConnectedMqttEventMapper>(flux, organization);
                return (IReadOnlyCollection<T>)results.Select(mapper => new ClientConnectedMqttEvent(mapper.Id)
                {
                    ClientId = mapper.ClientId,
                    Username = mapper.Username,
                    ConnectedAt = mapper.ConnectedAt,
                    Timestamp = mapper.Timestamp
                }).ToList();
            }
            else if (typeof(T) == typeof(ClientDisconnectedMqttEvent))
            {
                var results = await queryApi.QueryAsync<ClientDisconnectedMqttEventMapper>(flux, organization);
                return (IReadOnlyCollection<T>)results.Select(mapper => new ClientDisconnectedMqttEvent(mapper.Id)
                {
                    ClientId = mapper.ClientId,
                    Username = mapper.Username,
                    DisconnectedAt = mapper.DisconnectedAt,
                    Reason = mapper.Reason,
                    Timestamp = mapper.Timestamp
                }).ToList();
            }
            else if (typeof(T) == typeof(MessagePublishedMqttEvent))
            {
                var results = await queryApi.QueryAsync<MessagePublishedMqttEventMapper>(flux, organization);
                return (IReadOnlyCollection<T>)results.Select(mapper => new MessagePublishedMqttEvent(mapper.Id)
                {
                    ClientId = mapper.ClientId,
                    Username = mapper.Username,
                    MessageId = mapper.MessageId,
                    Payload = mapper.Payload,
                    Topic = mapper.Topic,
                    QualityofService = mapper.QualityofService,
                    RetainFlag = mapper.RetainFlag,
                    DupFlag = mapper.DupFlag,
                    PublishReceivedAt = mapper.PublishReceivedAt,
                    Timestamp = mapper.Timestamp
                }).ToList();
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Mqtt 事件映射器
        /// </summary>
        private abstract record MqttEventMapper
        {
            /// <summary>
            /// 事件 Id
            /// </summary>
            [Column(nameof(MqttEvent.Id), IsTag = true)]
            public long Id { get; init; } = 0;

            /// <summary>
            /// 客户端 Id
            /// </summary>
            [Column(nameof(MqttEvent.ClientId), IsTag = true)]
            public string ClientId { get; init; } = string.Empty;

            /// <summary>
            /// 用户名称
            /// </summary>
            [Column(nameof(MqttEvent.Username), IsTag = true)]
            public string Username { get; init; } = string.Empty;

            /// <summary>
            /// 事件触发时间
            /// <para>单位为毫秒</para>
            /// </summary>
            [Column(IsTimestamp = true)]
            public long Timestamp { get; init; } = 0;
        }

        /// <summary>
        /// 客户端已连接 Mqtt 事件映射器
        /// </summary>
        [Measurement(nameof(ClientConnectedMqttEvent))]
        private record ClientConnectedMqttEventMapper : MqttEventMapper
        {
            /// <summary>
            /// 连接完成时间
            /// <para>单位为毫秒</para>
            /// </summary>
            [Column(nameof(ClientConnectedMqttEvent.ConnectedAt))]
            public long ConnectedAt { get; init; } = 0;
        }

        /// <summary>
        /// 客户端连接已断开 Mqtt 事件映射器
        /// </summary>
        [Measurement(nameof(ClientDisconnectedMqttEvent))]
        private record ClientDisconnectedMqttEventMapper : MqttEventMapper
        {
            /// <summary>
            /// 连接断开时间
            /// <para>单位为毫秒</para>
            /// </summary>
            [Column(nameof(ClientDisconnectedMqttEvent.DisconnectedAt))]
            public long DisconnectedAt { get; init; } = 0;

            /// <summary>
            /// 客户端连接断开原因
            /// </summary>
            [Column(nameof(ClientDisconnectedMqttEvent.Reason), IsTag = true)]
            public ClientDisconnectReason Reason { get; init; } = ClientDisconnectReason.Unknown;
        }

        /// <summary>
        /// 消息已发布 Mqtt 事件映射器
        /// </summary>
        [Measurement(nameof(MessagePublishedMqttEvent))]
        private record MessagePublishedMqttEventMapper : MqttEventMapper
        {
            /// <summary>
            /// 消息 Id
            /// </summary>
            [Column(nameof(MessagePublishedMqttEvent.MessageId), IsTag = true)]
            public string MessageId { get; init; } = string.Empty;

            /// <summary>
            /// 消息负载
            /// </summary>
            [Column(nameof(MessagePublishedMqttEvent.Payload))]
            public string Payload { get; init; } = string.Empty;

            /// <summary>
            /// 消息主题
            /// </summary>
            [Column(nameof(MessagePublishedMqttEvent.Topic), IsTag = true)]
            public string Topic { get; init; } = string.Empty;

            /// <summary>
            /// 服务质量
            /// </summary>
            [Column(nameof(MessagePublishedMqttEvent.QualityofService))]
            public QualityofService QualityofService { get; init; } = QualityofService.AtMostOnce;

            /// <summary>
            /// 是否为保留消息
            /// </summary>
            [Column(nameof(MessagePublishedMqttEvent.RetainFlag))]
            public bool RetainFlag { get; init; } = false;

            /// <summary>
            /// 是否为重复消息
            /// </summary>
            [Column(nameof(MessagePublishedMqttEvent.DupFlag))]
            public bool DupFlag { get; init; } = false;

            /// <summary>
            /// 消息到达 Broker 的时间
            /// <para>单位为毫秒</para>
            /// </summary>
            [Column(nameof(MessagePublishedMqttEvent.PublishReceivedAt))]
            public long PublishReceivedAt { get; init; } = 0;
        }
    }
}