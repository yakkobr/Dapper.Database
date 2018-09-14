﻿using System.Threading.Tasks;
using Xunit;
using FactAttribute = Xunit.SkippableFactAttribute;

namespace Dapper.Tests.Database
{
    public abstract partial class TestSuite
    {
        [Fact]
        [Trait("Category", "Count")]
        public async Task CountNonGenericAsync()
        {
            using (var db = GetSqlDatabase())
            {
                Assert.Equal(89, await db.CountAsync("select * from Product where Color = 'Black'"));
            }
        }

        [Fact]
        [Trait("Category", "Count")]
        public async Task CountNonGenericParameterAsync()
        {
            using (var db = GetSqlDatabase())
            {
                Assert.Equal(89, await db.CountAsync($"select * from Product where Color = {P}Color", new { Color = "Black" }));
            }
        }

        [Fact]
        [Trait("Category", "Count")]
        public async Task CountNonGenericWithOrderClauseAsync()
        {
            using (var db = GetSqlDatabase())
            {
                Assert.Equal(89, await db.CountAsync("select * from Product where Color = 'Black' order by Color"));
            }
        }

        [Fact]
        [Trait("Category", "CountAsync")]
        public async Task CountAllAsync()
        {
            using (var connection = GetSqlDatabase())
            {
                Assert.Equal(295, await connection.CountAsync<Product>());
            }
        }

        [Fact]
        [Trait("Category", "CountAsync")]
        public async Task CountWithWhereClauseAsync()
        {
            using (var connection = GetSqlDatabase())
            {
                Assert.Equal(89, await connection.CountAsync<Product>("where Color = 'Black'"));
            }
        }

        [Fact]
        [Trait("Category", "CountAsync")]
        public async Task CountWithWhereClauseParameterAsync()
        {
            using (var connection = GetSqlDatabase())
            {
                Assert.Equal(89, await connection.CountAsync<Product>($"where Color = {P}Color", new { Color = "Black" }));
            }
        }

        [Fact]
        [Trait("Category", "CountAsync")]
        public async Task CountWithSelectClauseAsync()
        {
            using (var connection = GetSqlDatabase())
            {
                Assert.Equal(89, await connection.CountAsync<Product>("select * from Product where Color = 'Black'"));
            }
        }

        [Fact]
        [Trait("Category", "CountAsync")]
        public async Task CountWithSelectClauseParameterAsync()
        {
            using (var connection = GetSqlDatabase())
            {
                Assert.Equal(89, await connection.CountAsync<Product>($"select * from Product where Color = {P}Color", new { Color = "Black" }));
            }
        }

        [Fact]
        [Trait("Category", "CountAsync")]
        public async Task CountShortCircuitAsync()
        {
            using (var connection = GetSqlDatabase())
            {
                Assert.Equal(89, await connection.CountAsync<Product>($";select count(*) from Product where Color = {P}Color", new { Color = "Black" }));
            }
        }
    }
}
