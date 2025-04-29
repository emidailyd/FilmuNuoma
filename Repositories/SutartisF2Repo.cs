namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;

using Newtonsoft.Json;
using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;
using System.Collections.Generic;

/// <summary>
/// Database operations related to 'Sutartis' entity.
/// </summary>
public class SutartisF2Repo : RepoBase
{
    public static List<Sutartis> ListSutartis()
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}sutartys` ORDER BY numeris ASC";
        var drc = Sql.Query(query);
        return Sql.MapAll<Sutartis>(drc, (dre, t) => new Sutartis
        {
            Numeris = dre.From<int>("numeris"),
            PirkimoData = dre.From<DateTime>("pirkimo_data"),
            Kaina = dre.From<decimal>("kaina"),
            PristatymoArKitiMokesciai = dre.From<decimal>("pristatymo_ar_kiti_mokesciai"),
            GrazinimoAdresas = dre.From<string>("grazinimo_adresas"),
            PristatymoAdresas = dre.From<string>("pristatymo_adresas"),
            PristatymoKaina = dre.From<decimal>("pristatymo_kaina"),
            UzsakymoBusena = dre.From<string>("uzsakymo_busena")
        });
    }

    public static Sutartis Find(int numeris)
    {
        var query = $@"SELECT * FROM `{Config.TblPrefix}sutartys` WHERE numeris = @numeris";
        var drc = Sql.Query(query, cmd => cmd.Add("numeris", numeris));
        return Sql.MapOne<Sutartis>(drc, (dre, t) => new Sutartis
        {
            Numeris = dre.From<int>("numeris"),
            PirkimoData = dre.From<DateTime>("pirkimo_data"),
            Kaina = dre.From<decimal>("kaina"),
            PristatymoArKitiMokesciai = dre.From<decimal>("pristatymo_ar_kiti_mokesciai"),
            GrazinimoAdresas = dre.From<string>("grazinimo_adresas"),
            PristatymoAdresas = dre.From<string>("pristatymo_adresas"),
            PristatymoKaina = dre.From<decimal>("pristatymo_kaina"),
            UzsakymoBusena = dre.From<string>("uzsakymo_busena")
        });
    }

    public static int InsertSutartis(Sutartis sut)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}sutartys`
                      (pirkimo_data, kaina, pristatymo_ar_kiti_mokesciai, grazinimo_adresas,
                       pristatymo_adresas, pristatymo_kaina, uzsakymo_busena)
                      VALUES (@pirkimo_data, @kaina, @pristatymo_ar_kiti_mokesciai, @grazinimo_adresas,
                              @pristatymo_adresas, @pristatymo_kaina, @uzsakymo_busena)";
        return (int)Sql.Insert(query, cmd =>
        {
            cmd.Add("pirkimo_data", sut.PirkimoData);
            cmd.Add("kaina", sut.Kaina);
            cmd.Add("pristatymo_ar_kiti_mokesciai", sut.PristatymoArKitiMokesciai);
            cmd.Add("grazinimo_adresas", sut.GrazinimoAdresas);
            cmd.Add("pristatymo_adresas", sut.PristatymoAdresas);
            cmd.Add("pristatymo_kaina", sut.PristatymoKaina);
            cmd.Add("uzsakymo_busena", sut.UzsakymoBusena);
        });
    }

    public static void UpdateSutartis(Sutartis sut)
    {
        var query = $@"UPDATE `{Config.TblPrefix}sutartys`
                      SET pirkimo_data = @pirkimo_data,
                          kaina = @kaina,
                          pristatymo_ar_kiti_mokesciai = @pristatymo_ar_kiti_mokesciai,
                          grazinimo_adresas = @grazinimo_adresas,
                          pristatymo_adresas = @pristatymo_adresas,
                          pristatymo_kaina = @pristatymo_kaina,
                          uzsakymo_busena = @uzsakymo_busena
                      WHERE numeris = @numeris";
        Sql.Update(query, cmd =>
        {
            cmd.Add("pirkimo_data", sut.PirkimoData);
            cmd.Add("kaina", sut.Kaina);
            cmd.Add("pristatymo_ar_kiti_mokesciai", sut.PristatymoArKitiMokesciai);
            cmd.Add("grazinimo_adresas", sut.GrazinimoAdresas);
            cmd.Add("pristatymo_adresas", sut.PristatymoAdresas);
            cmd.Add("pristatymo_kaina", sut.PristatymoKaina);
            cmd.Add("uzsakymo_busena", sut.UzsakymoBusena);
            cmd.Add("numeris", sut.Numeris);
        });
    }

    public static void DeleteSutartis(int nr)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}sutartys` where numeris = @nr";
        Sql.Delete(query, cmd => cmd.Add("nr", nr));
    }

    public static List<UzsakytaPreke> ListUzsakytaPaslauga(int sutartisId)
    {
        var query = $@"SELECT up.* FROM `{Config.TblPrefix}uzsakytos_prekes` up
                      WHERE up.fk_sutartis = @sutartisId
                      ORDER BY up.fk_preke ASC";

        var drc = Sql.Query(query, cmd => cmd.Add("sutartisId", sutartisId));

        return Sql.MapAll<UzsakytaPreke>(drc, (dre, t) => new UzsakytaPreke
        {
            Id = dre.From<int>("id"),
            Kiekis = dre.From<int>("kiekis"),
            Kaina = dre.From<decimal>("kaina"),
            PrekeId = dre.From<int>("fk_preke"),
            SutartisNumeris = dre.From<int>("fk_sutartis")
        });
    }

    public static void InsertUzsakytaPaslauga(int sutartisId, UzsakytaPreke up)
    {
        var query = $@"INSERT INTO `{Config.TblPrefix}uzsakytos_prekes`
                      (fk_sutartis, fk_preke, kiekis, kaina)
                      VALUES (@fk_sutartis, @fk_preke, @kiekis, @kaina)";
        Sql.Insert(query, cmd =>
        {
            cmd.Add("fk_sutartis", sutartisId);
            cmd.Add("fk_preke", up.PrekeId);
            cmd.Add("kiekis", up.Kiekis);
            cmd.Add("kaina", up.Kaina);
        });
    }

    public static void DeleteUzsakytaPaslaugaForSutartis(int sutartisId)
    {
        var query = $@"DELETE FROM `{Config.TblPrefix}uzsakytos_prekes` WHERE fk_sutartis = @fk_sutartis";
        Sql.Delete(query, cmd => cmd.Add("fk_sutartis", sutartisId));
    }
}