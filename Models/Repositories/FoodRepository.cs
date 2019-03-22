using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FoodNutrition.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodNutrition.Models.Repositories
{
  public class FoodRepository : Repository<Food>, IFoodRepository
  {
    protected readonly FoodNutritionDBContext Context;

    public FoodRepository(FoodNutritionDBContext context) : base(context)
    {
      Context = context;
    }

    public IEnumerable<Food> GetFoodByNutrientRange(string query)
    {
      if (String.IsNullOrEmpty(query))
      {
        return Context.Food.ToList();
      }
      else
      {
        string condition = GetQueryConditions(query);
        List<int> foodIds = GetFoodIdsByNutrientRange(condition);
        return Context.Food.Where(f => foodIds.Contains(f.Id));
      }
    }

    private string GetQueryConditions(string query)
    {
      string condition = "";
      string[] or_cond = query.Split("OR");

      for(int i= 0; i < or_cond.Length; i++)
      {
        string[] and_cond = or_cond[i].Split("AND");

        for (int j = 0; j < and_cond.Length; j++)
        {
          string replace = "NutrientId = $1 AND Gm $2 $3";
          string text = Regex.Replace(and_cond[j], "\\w+:(\\d+)(>=|>|<|<=|=)(\\d+)", replace);
          text = "sum(CASE WHEN " + text.Trim() + " THEN 1 ELSE 0 END)> 0";

          if (j != and_cond.Length - 1)
          {
            condition += text + " AND ";
          }
          else
          {
            condition += text;
          }
        }
        if (i != or_cond.Length - 1)
        {
          condition += " OR ";
        }
      }
      return condition;
    }
    private List<int> GetFoodIdsByNutrientRange(string query)
    {
      List<int> foodIds = new List<int>();
      var conn = Context.Database.GetDbConnection();
      try
      {
        conn.OpenAsync();
        using (var command = conn.CreateCommand())
        {
          string text = "SELECT FoodId  FROM FoodNutrient GROUP BY FoodId Having "+ query;
          command.CommandText = text;
          DbDataReader reader = command.ExecuteReader();

          if (reader.HasRows)
          {
            while (reader.Read())
            {
              var foodId = reader.GetInt32(0);
              foodIds.Add(foodId);
            }
          }
          reader.Dispose();
        }
      }
      finally
      {
        conn.Close();
      }

      return foodIds;
    }
  }
}
