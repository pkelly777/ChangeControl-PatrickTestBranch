using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChangeControl.Models;
using ChangeControlApp.Models;

namespace ChangeControlApp.Models
{
    public class Impact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QmsProceduresProcesses { get; set; }
        public string OtherDocumentation { get; set; }
        public string FinishedProduct { get; set; }
        public string ExistMaterialStockFinishProd { get; set; }
        public string ProdCustSpec { get; set; }
        public string MaterialQualification { get; set; }
        public string ProductValidation { get; set; }
        public string ProcessValidation { get; set; }
        public string TestEquipMethodsCalib { get; set; }
        public string RegulatoryReq { get; set; }
        public string SupplierAgreementsSpec { get; set; }
        public string CustomerReqSpec { get; set; }
        public string NewExistEquipSoftware { get; set; }
        public string Cleaning { get; set; }
        public string Maintenance { get; set; }
        public string Environment { get; set; }
        public string ManufWorkFlowAncillaryPkgEquip { get; set; }
        public string Other { get; set; }

        
        public int ChangeLogId { get; set; }
        public ChangeLog ChangeLog { get; set; }

    }
}
