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
        public static List<User> CreateUser => new()
        {
            new User
            {
                Id = 1 ,Username = "Roham_1234" ,Password = "987654321" ,PhoneNumber = 09351305594
            },

            new User
            {
                Id = 2 ,Username = "Mamad_jkbg" ,Password = "6387492" ,PhoneNumber = 09397821343
            },

            new User
            {
                Id = 3 ,Username = "Taha_45d" ,Password = "123456789" ,PhoneNumber = 09905679299
            },

            new User
            {
                Id = 4 ,Username = "Ali_V88" ,Password = "456123" ,PhoneNumber = 09196678932
            }

        };

        public static List<Car> CreateCar => new()
        {
            new Car
            {
                Id = 1 ,CarName = "MC Laren",ChassisNumber = "NABN3879823832" ,Owner = new User(1,"Roham_1234","987654321",09351305594)
            },

            new Car
            {
                Id = 2 ,CarName = "207" ,ChassisNumber = "AHYU329875356" ,Owner = new User(2,"Mamad_jkbg","6387492",09397821343)
            },

            new Car
            {
                Id = 3 ,CarName = "Dodge Challenger" ,ChassisNumber = "POQA492378389" ,Owner = new User(3,"Taha_45d","123456789",09905679299)
            },

            new Car
            {
                Id = 4, CarName = "Tiwooli" ,ChassisNumber = "YBVZ193789132" ,Owner = new User(4,"Ali_V88","456123",09196678932)
            }
        };

        public static List<TakingTurn> CreateTurn => new()
        {
            new TakingTurn
            {
                Id = 1 ,CarId = 1 ,CenterId = 1 ,Capacity = 2 ,ReserveStatus = ReserveStatus.IsReserve ,ResultText = "Turn Is Available"
            },
            new TakingTurn
            {
                Id = 2 ,CarId = 2 ,CenterId = 2 ,Capacity = 1 ,ReserveStatus = ReserveStatus.IsReserve ,ResultText = "Turn Is Available"
            },
            new TakingTurn
            {
                Id = 3 ,CarId = 3 ,CenterId = 3 ,Capacity = 4 ,ReserveStatus = ReserveStatus.IsReserve ,ResultText = "Turn Is Available"
            },
            new TakingTurn
            {
                Id = 4 ,CarId = 4 ,CenterId = 4 ,Capacity = 2 ,ReserveStatus = ReserveStatus.IsReserve ,ResultText = "Turn Is Available"
            }
        };

        public static List<TechnicalExaminationCenter> CreateCenter => new()
        {
            new TechnicalExaminationCenter
            {
                Id = 1 ,Name = "Center 1" ,Address = "Tehran_" ,Status = Status.Active ,TurnCount = 3
            },

            new TechnicalExaminationCenter
            {
                Id = 2 ,Name = "Center 2" ,Address = "Karaj_" ,Status = Status.Active ,TurnCount = 1
            },

            new TechnicalExaminationCenter
            {
                Id = 3 ,Name = "Center 3" ,Address = "Shiraz_" ,Status = Status.Active ,TurnCount = 2
            },

            new TechnicalExaminationCenter
            {
                Id = 4 ,Name = "Center 4" ,Address = "Ardabil_" ,Status = Status.Active ,TurnCount = 2
            },
        };

        public static List<City> CreateCity => new()
        {
            new City
            {
                Id = 1 ,Name = "Tehran"
            },

            new City
            {
                Id = 2 ,Name = "Karaj"
            }
        };

        public static List<Province> CreateProvince => new()
        {
            new Province
            {
                Id = 1 ,Name = "Tehran"
            },

            new Province
            {
                Id = 1, Name = "Alborz"
            }
        };
    }
}
