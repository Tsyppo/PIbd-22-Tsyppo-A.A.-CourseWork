﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoToWorkContracts.BindingModels;
using GoToWorkContracts.ViewModels;

namespace GoToWorkContracts.StoragesContracts
{
    public interface IMachineStorage
    {
        List<MachineViewModel> GetFullList();
        List<MachineViewModel> GetFilteredList(MachineBindingModel model);
        MachineViewModel GetElement(MachineBindingModel model);
        void Insert(MachineBindingModel model);
        void Update(MachineBindingModel model);
        void Delete(MachineBindingModel model);
    }
}
