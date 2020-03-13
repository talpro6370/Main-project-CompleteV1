using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using MainProject;
using System.Threading;
using System.Windows.Input;
using System.ComponentModel;

namespace part2
{
    public class MainWindowViewModel 
    {
        public MainProject.Business_Logic.LoggedInAdministratorFacade mProjectAmdinFc;
        CheckDataBase cData = new CheckDataBase();
        public WorkWithDB dbInsertClass { get; set; }
        public DelegateCommand AddToDB { get; set; }
        public DelegateCommand ReplaceDB { get; set; }
        public WorkWithAPI apiWorker = new WorkWithAPI();
        public string AirlineNo { get; set; }
        public string CustomerNo { get; set; }
        public string FlightsPerCmpnyNo { get; set; }
        public string TicketsPerCustNo { get; set; }
        public string CountriesNo { get; set; }
        public bool isTextHasChanged { get; set; }
        public int ProggressBarVal { get; set; }

        public int sumOfObjectsToCreate = 0;
        public int SumInPercentage { get; set; }

        public MainWindowViewModel()
        {
            dbInsertClass = new WorkWithDB();
            AddToDB = new DelegateCommand(ExecuteAddDelegateCmd, CanExecuteAddBtnMethod);
            ReplaceDB = new DelegateCommand(ExecuteReplaceDelegateCmd, CanExecuteReplaceBtnMethod);
            Task.Run(() =>
           {
               while (true)
               {
                   AddToDB.RaiseCanExecuteChanged();
                   Thread.Sleep(100);
               }
           });

            Task.Run(() =>
            {
                while (true)
                {
                    ReplaceDB.RaiseCanExecuteChanged();
                    Thread.Sleep(100);
                }
            });
        }   
        private async void ExecuteAddDelegateCmd()
        {
           await dbInsertClass.InsertingDataBase(AirlineNo,CustomerNo,FlightsPerCmpnyNo,TicketsPerCustNo,CountriesNo);
        }
        private bool CanExecuteAddBtnMethod()
        {
            if (cData.DataBaseStatus() == true)
                return true;
            return false;
        }
        private void ExecuteReplaceDelegateCmd()
        {
            dbInsertClass.RemoveDB();     
        }
        private bool CanExecuteReplaceBtnMethod()
        {
            if (cData.DataBaseStatus()==false)
                return true;
            return false;
        }

    }
}
