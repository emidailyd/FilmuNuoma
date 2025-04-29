﻿namespace Org.Ktu.Isk.P175B602.FilmuNuoma.Repositories;

using Org.Ktu.Isk.P175B602.FilmuNuoma.Models;



/// <summary>
/// Database operations related to 'Aikstele' entity.
/// </summary>
public class AiksteleRepo : RepoBase
{
	public static List<Aikstele> List()
	{
		var query = $@"SELECT * FROM `{Config.TblPrefix}aiksteles` ORDER BY id ASC";
		var drc = Sql.Query(query);

		var result = 
			Sql.MapAll<Aikstele>(drc, (dre, t) => {
				t.Id = dre.From<int>("id");
				t.Pavadinimas = dre.From<string>("pavadinimas");
				t.Adresas = dre.From<string>("adresas");
				t.FkMiestas = dre.From<int>("fk_miestas");
			});

		return result;
	}
}
