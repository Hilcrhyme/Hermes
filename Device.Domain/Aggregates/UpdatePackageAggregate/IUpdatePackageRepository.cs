using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hermes.Common.SeedWork;

namespace Hermes.Service.Device.Domain.Aggregates.UpdatePackageAggregate
{
    /// <summary>
    /// 更新包仓储接口
    /// </summary>
    public interface IUpdatePackageRepository : IRepository<UpdatePackage>
    {
        /// <summary>
        /// 新增更新包
        /// </summary>
        /// <param name="updatePackage">更新包</param>
        /// <returns></returns>
        UpdatePackage AddUpdatePackage(UpdatePackage updatePackage);
    }
}