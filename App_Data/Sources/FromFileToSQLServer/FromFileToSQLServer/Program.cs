using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using FromFileToSQLServer.Services;

namespace FromFileToSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new FileService();
            var supplementsRelations = fileService.GetRelationInformation().ToList();
            //var supplements = fileService.GetSupplements();
            //var supService = new SupplementService();
            //supService.SetSupplements(supplements);

            var relService = new RelationInformationService();
            relService.SetSupplementsRelationInformation(supplementsRelations);
        }
    }
}
