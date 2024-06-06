using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using nutriapi.Models;
using System.Linq.Expressions;
using System.Net;

namespace nutriapi.Services
{
    public class MetabolismoCalculator
    {

        private readonly List<BasalModel> _basalModels = new List<BasalModel>();

        public void AddBasalModel(BasalModel model)
        {
            _basalModels.Add(model);
        }

        public IEnumerable<BasalModel> GetBasalModels()
        {
            return _basalModels;
        }

        public double CalculateBasalMetabolism(BasalModel basalModel)
        {
            try
            {
                double basalMetabolism;
                switch (basalModel.Sexo)
                {
                    case "F":
                        //66 + (13,7 x peso em kg) + (5 x altura em cm) - (6,8 x idade em anos)
                        basalMetabolism = 66 + (13.7 * basalModel.Peso) + (5 * basalModel.Altura) - (6.8 * basalModel.Idade);
                        return basalMetabolism;
                        break;
                    case "M":
                        //655 + (9,6 x peso em kg) + (1,8 x altura em cm) - (4,7 x idade em anos)
                        basalMetabolism = 655 + (9.6 * basalModel.Peso) + (1.8 * basalModel.Altura) - (4.7 * basalModel.Idade);
                        return basalMetabolism;
                        break;
                    default:
                        return 0;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sexo Feminino(F) ou Masculino(M)", e.Message);
                return default;
            }

        }




    }
}

            // Fórmula de Harris-Benedict
            /*try
            {
                double basalMetabolism;
                if (basalModel.Sexo != "F")
                {
                    //66 + (13,7 x peso em kg) + (5 x altura em cm) - (6,8 x idade em anos)
                    basalMetabolism = 66 + (13.7 * basalModel.Peso) + (5 * basalModel.Altura) - (6.8 * basalModel.Idade);
                }
                else if (basalModel.Sexo != "M")
                {
                    //655 + (9,6 x peso em kg) + (1,8 x altura em cm) - (4,7 x idade em anos)
                    basalMetabolism = 655 + (9.6 * basalModel.Peso) + (1.8 * basalModel.Altura) - (4.7 * basalModel.Idade);
                }
                else
                {
                basalMetabolism = 655 + (9.6 * basalModel.Peso) + (1.8 * basalModel.Altura) - (4.7 * basalModel.Idade);
                }
                return basalMetabolism;
            }
            catch (Exception e)
            {
                Console.WriteLine("Sexo Feminino(F) ou Masculino(M)", e.Message);
                return default;
            }*/