﻿using _1.Database;
using _1.Filters.PrepodKafedraFilters;
using _1.Interfaces.PrepodInterfaces;
using _1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platonova_Maria_KT_42_20_Tests
{
    public class PrepodIntegrationTests
    {
        public readonly DbContextOptions<PrepodDbcontext> _dbContextOptions;

        public PrepodIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PrepodDbcontext>()
            .UseInMemoryDatabase(databaseName: "prepod_db")
            .Options;
        }

        [Fact]
        public async Task GetPrepodByKafedraAsync_KT4220_OneObjects()
        {
            // Arrange
            var ctx = new PrepodDbcontext(_dbContextOptions);
            var prepodService = new PrepodService(ctx);
            var kafedra = new List<Kafedra>
            {
                new Kafedra
                {
                    KafedraId =1,
                    KafedraName = "кафедра компьютерных технологий"
                },
                new Kafedra
                {
                    KafedraId =2,
                    KafedraName = "кафедра инженерной техники"
                }
            };
            await ctx.Set<Kafedra>().AddRangeAsync(kafedra);

            await ctx.SaveChangesAsync();

            var stepen = new List<Stepen>
            {
                new Stepen
                {
                    StepenId =1,
                    StepenName = "доктор наук"
                },
                new Stepen
                {
                    StepenId =2,
                    StepenName = "кандидат наук"
                }
            };
            await ctx.Set<Stepen>().AddRangeAsync(stepen);

            await ctx.SaveChangesAsync();

            var prepods = new List<Prepod>
            {
                new Prepod
                {
                    FirstName = "123",
                    LastName = "123",
                    MiddleName = "123",
                    Phone = "555",
                    KafedraId = 1,
                    StepenId = 2
                },
                new Prepod
                {
                    FirstName = "mem",
                    LastName = "mem",
                    MiddleName = "mem",
                    Phone = "9999",
                    KafedraId = 1,
                    StepenId = 2
                },
                new Prepod
                {
                    FirstName = "mem1",
                    LastName = "mem1",
                    MiddleName = "mem1",
                    Phone = "99991",
                    KafedraId = 2,
                    StepenId = 2
                }
            };
            await ctx.Set<Prepod>().AddRangeAsync(prepods);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new PrepodKafedraFilter
            {
                KafedraName = "кафедра компьютерных технологий"
            };
            var prepodsResult = await prepodService.GetPrepodsByKafedraAsync(filter, CancellationToken.None);

            Assert.Equal(2, prepodsResult.Length);
        }
    }
}
