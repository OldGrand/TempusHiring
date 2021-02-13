using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Services.Interfaces.Common;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IColorService : ICrudService<ColorDTO>
    {
    }
}
