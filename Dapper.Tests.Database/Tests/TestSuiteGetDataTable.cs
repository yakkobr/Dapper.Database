﻿#if !NETSTANDARD1_3 && !NETCOREAPP1_0
using Xunit;
using FactAttribute = Xunit.SkippableFactAttribute;

namespace Dapper.Tests.Database
{
    public abstract partial class TestSuite
    {
        [Fact]
        [Trait("Category", "GetDataTable")]
        public void GetDataTable()
        {
            if (GetProvider() != Provider.SQLite)
            {
                using (var db = GetSqlDatabase())
                {
                    var dt = db.GetDataTable("select * from Product where Color = 'Black'");
                    Assert.Equal(89, dt.Rows.Count);
                }
            }
        }

        [Fact]
        [Trait("Category", "GetDataTable")]
        public void GetDataTableWithParameter()
        {
            if (GetProvider() != Provider.SQLite)
            {
                using (var db = GetSqlDatabase())
                {
                    var dt = db.GetDataTable($"select * from Product where Color = {P}Color", new { @Color = "Black" });
                    Assert.Equal(89, dt.Rows.Count);
                }
            }
        }
    }
}
#endif
