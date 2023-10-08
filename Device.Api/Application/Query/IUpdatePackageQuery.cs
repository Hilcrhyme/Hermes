using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.Command;
using Hermes.Service.Device.Api.Application.DataTransferObject;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新包查询接口
    /// </summary>
    public interface IUpdatePackageQuery
    {
        /// <summary>
        /// 异步查询更新包
        /// </summary>
        /// <param name="updatePackageQueryCommand">更新包查询命令</param>
        /// <returns></returns>
        Task<QueryResult<UpdatePackage>> QueryUpdatePackagesAsync(UpdatePackageQueryCommand updatePackageQueryCommand);
    }
}