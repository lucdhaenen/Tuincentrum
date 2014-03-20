using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TuincentrumBase
{
    public class TuinManager
    {
        public Decimal BerekenGemiddeldePrijs(string soort)
        {
            var dbManager = new TuinDbManager();
            using (var conTuin = dbManager.GetConnection())
            {
                using (var comTuin = conTuin.CreateCommand())
                {
                    comTuin.CommandType = CommandType.StoredProcedure;
                    comTuin.CommandText = "BerekenGemiddeldePrijs";
                    var parSoort = comTuin.CreateParameter();
                    parSoort.ParameterName = "@soort";
                    parSoort.Value = soort;
                    comTuin.Parameters.Add(parSoort);
                    conTuin.Open();
                    Object resultaat = comTuin.ExecuteScalar();
                    if (resultaat == null)
                    {
                        throw new Exception("soort bestaat niet");
                    }
                    else
                    {
                        return (decimal)resultaat;
                    }
                }
            }
        }

        public PlantGegevens PlantGegevensOpzoeken(int plantNr)
        {
            var manager = new TuinDbManager();
            using (var conTuin = manager.GetConnection())
            {
                using (var comPlantGegevens = conTuin.CreateCommand())
                {
                    comPlantGegevens.CommandType = CommandType.StoredProcedure;
                    comPlantGegevens.CommandText = "PlantenGegevens";
                    var parPlantNr = comPlantGegevens.CreateParameter();
                    parPlantNr.ParameterName = "@plantnr";
                    parPlantNr.Value = plantNr;
                    comPlantGegevens.Parameters.Add(parPlantNr);
                    var parPlantNaam = comPlantGegevens.CreateParameter();
                    parPlantNaam.ParameterName = "@plantnaam";
                    parPlantNaam.DbType = DbType.String;
                    parPlantNaam.Size = 30;
                    parPlantNaam.Direction = ParameterDirection.Output;
                    comPlantGegevens.Parameters.Add(parPlantNaam);
                    var parSoort = comPlantGegevens.CreateParameter();
                    parSoort.ParameterName = "@soort";
                    parSoort.DbType = DbType.String;
                    parSoort.Size = 10;
                    parSoort.Direction = ParameterDirection.Output;
                    comPlantGegevens.Parameters.Add(parSoort);
                    var parLeverancier = comPlantGegevens.CreateParameter();
                    parLeverancier.ParameterName = "@leverancier";
                    parLeverancier.DbType = DbType.String;
                    parLeverancier.Size = 30;
                    parLeverancier.Direction = ParameterDirection.Output;
                    comPlantGegevens.Parameters.Add(parLeverancier);
                    var parKleur = comPlantGegevens.CreateParameter();
                    parKleur.ParameterName = "@kleur";
                    parKleur.DbType = DbType.String;
                    parKleur.Size = 10;
                    parKleur.Direction = ParameterDirection.Output;
                    comPlantGegevens.Parameters.Add(parKleur);
                    var parKostprijs = comPlantGegevens.CreateParameter();
                    parKostprijs.ParameterName = "@kostprijs";
                    parKostprijs.DbType = DbType.Currency;
                    parKostprijs.Direction = ParameterDirection.Output;
                    comPlantGegevens.Parameters.Add(parKostprijs);
                    conTuin.Open();
                    comPlantGegevens.ExecuteNonQuery();
                    if (parPlantNaam.Value.Equals(DBNull.Value))
                    { throw new Exception("Plantgegevens niet gevonden"); }
                    return new PlantGegevens(parPlantNaam.Value.ToString(),
                    parSoort.Value.ToString(), parLeverancier.Value.ToString(),
                    parKleur.Value.ToString(), (Decimal)parKostprijs.Value);
                }
            }
        }

        public List<Soort> GetSoorten()
        {
            var soorten = new List<Soort>();
            var manager = new TuinDbManager();
            using (var conTuin = manager.GetConnection())
            {
                using (var comSoorten = conTuin.CreateCommand())
                {
                    comSoorten.CommandType = CommandType.Text;
                    comSoorten.CommandText = "select SoortNr, Soort from Soorten order by Soort";
                    conTuin.Open();
                    using (var rdrSoorten = comSoorten.ExecuteReader())
                    {
                        var soortPos = rdrSoorten.GetOrdinal("soort");
                        var soortnrPos = rdrSoorten.GetOrdinal("soortnr");
                        while (rdrSoorten.Read())
                        {
                            soorten.Add(new Soort(rdrSoorten.GetString(soortPos), rdrSoorten.GetInt32(soortnrPos)));
                        }
                    }
                }
            }
            return soorten;
        }

        public List<Plant> GetPlanten(int soortnr)
        {
            var planten = new List<Plant>();
            var manager = new TuinDbManager();
            using (var conTuin = manager.GetConnection())
            {
                using (var comPlanten = conTuin.CreateCommand())
                {
                    comPlanten.CommandType = CommandType.Text;
                    comPlanten.CommandText = "select plantnr, naam, levnr, verkoopprijs, kleur, soortnr from planten where soortnr=@soortnr order by naam"; 
                    var parSoortNr = comPlanten.CreateParameter();
                    parSoortNr.ParameterName = "@soortnr";
                    parSoortNr.Value = soortnr;
                    comPlanten.Parameters.Add(parSoortNr);
                    conTuin.Open();
                    using (var rdrPlanten = comPlanten.ExecuteReader())
                    {
                        var plantNaamPos = rdrPlanten.GetOrdinal("Naam"); 
                        var plantNrPos = rdrPlanten.GetOrdinal("plantnr");
                        var levnrPos = rdrPlanten.GetOrdinal("levnr");
                        var prijsPos = rdrPlanten.GetOrdinal("verkoopprijs");
                        var kleurPos = rdrPlanten.GetOrdinal("kleur");
                        var soortPos = rdrPlanten.GetOrdinal("soortnr");
                        while (rdrPlanten.Read())
                        {
                            var eenPlant = new Plant(
                                    rdrPlanten.GetString(plantNaamPos),
                                    rdrPlanten.GetInt32(plantNrPos),
                                    rdrPlanten.GetInt32(levnrPos),
                                    rdrPlanten.GetDecimal(prijsPos),
                                    rdrPlanten.GetString(kleurPos));
                            planten.Add(eenPlant); 
                        }
                    }
                }
            }
            return planten;
        }

        public List<Leverancier> GetLeveranciers (string naam)
        {
            List<Leverancier> leveranciers = new List<Leverancier>();
            var manager = new TuinDbManager();
            using (var conLeveranciers = manager.GetConnection())
            {
                using (var comLeveranciers = conLeveranciers.CreateCommand())
                {
                    comLeveranciers.CommandType = CommandType.Text;
                    if (naam != string.Empty)
                    {
                        comLeveranciers.CommandText = "SELECT * FROM Leveranciers WHERE Naam like @zoals order by Naam";
                        var parZoals = comLeveranciers.CreateParameter();
                        parZoals.ParameterName = "@zoals";
                        parZoals.Value = naam + "%";
                        comLeveranciers.Parameters.Add(parZoals);
                    }
                    else comLeveranciers.CommandText = "select * from Leveranciers order by Naam";
                    conLeveranciers.Open();
                    using (var rdrLeveranciers = comLeveranciers.ExecuteReader())
                    {
                        Int32 levNrPos = rdrLeveranciers.GetOrdinal("LevNr");
                        Int32 naamPos = rdrLeveranciers.GetOrdinal("Naam");
                        Int32 adresPos = rdrLeveranciers.GetOrdinal("Adres");
                        Int32 postNrPos = rdrLeveranciers.GetOrdinal("PostNr");
                        Int32 woonplaatsPos = rdrLeveranciers.GetOrdinal("Woonplaats");
                        while (rdrLeveranciers.Read())
                        {
                            leveranciers.Add(new Leverancier(rdrLeveranciers.GetInt32(levNrPos), rdrLeveranciers.GetString(naamPos),
                                rdrLeveranciers.GetString(adresPos), rdrLeveranciers.GetString(postNrPos), 
                                rdrLeveranciers.GetString(woonplaatsPos)));
                        }                        
                    }
                }
            }
            return leveranciers;
        }
    }
}
