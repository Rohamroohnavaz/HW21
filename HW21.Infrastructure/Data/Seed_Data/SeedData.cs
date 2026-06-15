using HW21.DomainLayer.Enums;
using HW21.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW21.Infrastructure.Data.Seed_Data
{
    public static class SeedData
    {
        public static List<Province> CreateProvince => new()
        {
            new Province
            {
                Id = 1 ,Name = "Tehran" ,CreatedAt = new DateTime(1930,4,12)
            },

            new Province
            {
                Id = 2, Name = "Alborz" ,CreatedAt = new DateTime(1932,7,2)
            },

            new Province
            {
                 Id = 3, Name = "Fars" ,CreatedAt = new DateTime(1938,8,1)
            },

            new Province
            {
                 Id = 4, Name = "Esfahan" ,CreatedAt = new DateTime(1920,7,2)
            }
        };

        public static List<City> CreateCity => new()
        {
            new City
            {
                Id = 1 ,Name = "Tehran" ,CreatedAt = new DateTime(1800,2,3) ,ProvinceId = 1
            },

            new City
            {
                Id = 2 ,Name = "Karaj" ,CreatedAt = new DateTime(1812,9,10) ,ProvinceId = 2
            },

            new City
            {
                Id = 3 ,Name = "Shiraz" ,CreatedAt = new DateTime(1812,9,10) ,ProvinceId = 3
            },

            new City
            {
                Id = 4 ,Name = "KhomeiniShahr" ,CreatedAt = new DateTime(1840,6,3) ,ProvinceId = 4
            }
        };

        public static List<TechnicalExaminationCenter> CreateCenter => new()
        {
            new TechnicalExaminationCenter
            {
                Id = 1 ,Name = "Center 1" ,Address = "Tehran_" ,Status = Status.Active
                ,TurnCount = 3 ,CreatedAt = new DateTime(2026,4,1) ,ProvinceId = 1 ,CityId = 1
            },

            new TechnicalExaminationCenter
            {
                Id = 2 ,Name = "Center 2" ,Address = "Karaj_" ,Status = Status.Active
                ,TurnCount = 1 ,CreatedAt = new DateTime(2019,10,3) ,ProvinceId = 2 ,CityId = 2
            },

            new TechnicalExaminationCenter
            {
                Id = 3 ,Name = "Center 3" ,Address = "Shiraz_" ,Status = Status.Active
                ,TurnCount = 2 ,CreatedAt = new DateTime(2020,6,7) ,ProvinceId = 3 ,CityId = 3
            },

            new TechnicalExaminationCenter
            {
                Id = 4 ,Name = "Center 4" ,Address = "Ardabil_" ,Status = Status.Active
                ,TurnCount = 2 ,CreatedAt = new DateTime(2024,6,1) ,ProvinceId = 4 ,CityId = 4
            },
        };

        public static List<User> CreateUser => new()
        {
            new User
            {
                Id = 1 ,Username = "Roham_1234" ,Password = "987654321" ,PhoneNumber = 09351305594 ,
                CreatedAt = new DateTime(2026,3,1)
            },

            new User
            {
                Id = 2 ,Username = "Mamad_jkbg" ,Password = "6387492" ,PhoneNumber = 09397821343 ,
                CreatedAt = new DateTime(2026,4,1)
            },

            new User
            {
                Id = 3 ,Username = "Taha_45d" ,Password = "123456789" ,PhoneNumber = 09905679299 ,
                CreatedAt = new DateTime(2026,5,1)
            },

            new User
            {
                Id = 4 ,Username = "Ali_V88" ,Password = "456123" ,PhoneNumber = 09196678932 ,
                CreatedAt = new DateTime(2026,6,1)
            }

        };

        public static List<Car> CreateCar => new()
        {
            new Car
            {
                Id = 1 ,CarName = "MC Laren",ChassisNumber = "NABN3879823832" ,UserId = 1 ,
                CreatedAt = new DateTime(2026,3,1)
            },

            new Car
            {
                Id = 2 ,CarName = "207" ,ChassisNumber = "AHYU329875356" ,UserId = 2 ,
                CreatedAt = new DateTime(2026,4,1)
            },

            new Car
            {
                Id = 3 ,CarName = "Dodge Challenger" ,ChassisNumber = "POQA492378389" ,UserId = 3 ,
                CreatedAt = new DateTime(2026,5,1)
            },

            new Car
            {
                Id = 4, CarName = "Tiwooli" ,ChassisNumber = "YBVZ193789132" ,UserId = 4 ,
                CreatedAt = new DateTime(2026,6,1)
            }
        };

        public static List<TimeManaging> CreateTime => new()
        {
            new TimeManaging
            {
                Id = 1 ,StartTime = new TimeSpan(5,0,0) ,EndTime = new TimeSpan(6,0,0) ,CenterId = 1
            },

            new TimeManaging
            {
                Id = 2 ,StartTime = new TimeSpan(2,0,0),EndTime = new TimeSpan(3,0,0) ,CenterId = 2
            },

            new TimeManaging
            {
                Id = 3 ,StartTime = new TimeSpan(1,0,0) ,EndTime = new TimeSpan(2,30,0) ,CenterId = 3
            },

            new TimeManaging
            {
                Id = 4 ,StartTime = new TimeSpan(4,30,0) ,EndTime = new TimeSpan(5,0,0) ,CenterId = 4
            }
        };

        public static List<TakingTurn> CreateTurn => new()
        {
            new TakingTurn
            {
                Id = 1 ,CarId = 1 ,CenterId = 1 ,Capacity = 2 ,ReserveStatus = ReserveStatus.IsReserve
                ,ResultText = "Turn Is Available" ,CityName = "Tehran" ,ProvinceName = "Tehran" ,
                CreatedAt = new DateTime(2026,2,2) ,TimeId = 1 ,Status = Status.Active
            },
            new TakingTurn
            {
                Id = 2 ,CarId = 2 ,CenterId = 2 ,Capacity = 1 ,ReserveStatus = ReserveStatus.IsReserve
                ,ResultText = "Turn Is Available" ,CityName = "Karaj" ,ProvinceName = "Alborz" ,
                CreatedAt = new DateTime(2026,8,3) ,TimeId = 2 ,Status = Status.Active
            },
            new TakingTurn
            {
                Id = 3 ,CarId = 3 ,CenterId = 3 ,Capacity = 4 ,ReserveStatus = ReserveStatus.IsReserve
                ,ResultText = "Turn Is Available" ,CityName = "Shiraz" ,ProvinceName = "Tehran" ,
                CreatedAt = new DateTime(2026,10,12) ,TimeId = 3 ,Status = Status.Active
            },
            new TakingTurn
            {
                Id = 4 ,CarId = 4 ,CenterId = 4 ,Capacity = 2 ,ReserveStatus = ReserveStatus.IsReserve
                ,ResultText = "Turn Is Available" ,CityName = "Esfahan" ,ProvinceName = "Alborz" ,
                CreatedAt = new DateTime(2026,9,8) ,TimeId = 4 ,Status = Status.Active
            }
        };
    }
}
