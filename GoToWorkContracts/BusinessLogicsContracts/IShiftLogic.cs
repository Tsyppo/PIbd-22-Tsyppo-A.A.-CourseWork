﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;

namespace GoToWorkContracts.BusinessLogicsContracts
{
    public interface IShiftLogic
    {
        List<ShiftViewModel> Read(ShiftBindingModel model);
        void CreateOrUpdate(ShiftBindingModel model);
        void Delete(ShiftBindingModel model);
    }
}
