using Hermes.Common.SeedWork;
using Hermes.Service.Device.Api.Application.DataTransferObject;

namespace Hermes.Service.Device.Api.Application.Query
{
    /// <summary>
    /// 更新包查询
    /// </summary>
    public class UpdatePackageQuery : IUpdatePackageQuery
    {
        /// <summary>
        /// 异步查询更新包
        /// </summary>
        /// <param name="updatePackageQueryCommand">更新包查询命令</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<QueryResult<UpdatePackage>> QueryUpdatePackagesAsync(UpdatePackageQueryRequest updatePackageQueryCommand)
        {
            throw new NotImplementedException();
        }
    }
}