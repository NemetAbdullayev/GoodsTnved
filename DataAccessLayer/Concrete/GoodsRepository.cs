using Dapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Tables;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DataAccessLayer.Concrete
{
    public class GoodsRepository : IGoodRepository 
    {
        private readonly DatabaseContext _databaseContext;


        SqlConnection conn;

        public GoodsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            conn = new SqlConnection (_databaseContext.GetConnectionString());
        }
        public async Task <Goods> GetByID(string code)
        {
            try
            {
                
                string querry = $@"WITH  ParentChain AS (
 SELECT id, Parent_Id
  FROM Goods_Tnved
  WHERE id = (select top 1 id from Goods_Tnved where code='{code}')
  
  UNION ALL
  

  SELECT t.id, t.Parent_Id
  FROM Goods_Tnved t
  INNER JOIN ParentChain pc ON t.id = pc.Parent_Id
)


SELECT DISTINCT TOP 1 Parent_Id
FROM ParentChain
ORDER BY Parent_Id DESC;";
                
                var parentId = conn.QueryFirstOrDefault<int>(querry);
                string parentQuerry = $@"select  * from Goods_Tnved where id={parentId}";
                Goods findParentGood = conn.QueryFirstOrDefault<Goods>(parentQuerry);
                string functionQuery = @$"select dbo.GetJson({parentId})";
                var jsonString = conn.QueryFirstOrDefault<string>(functionQuery) ; 
                
                var result = JsonConvert.DeserializeObject<List<Goods>>(jsonString);
                findParentGood.Children = result;
                return findParentGood;

            }
            catch (Exception e)
            {

                return null;
            }
        }
    }

       
    }
