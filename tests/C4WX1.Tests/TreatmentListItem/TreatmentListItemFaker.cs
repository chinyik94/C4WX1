using C4WX1.API.Features.TreatmentListItem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4WX1.Tests.TreatmentListItem;

public class TreatmentListItemFaker
{
    public static CreateTreatmentListItemDto CreateDto => new()
    {
        ItemName = "control-ItemName",
        ItemBrand = "control-ItemBrand",
        TListTypeID_FK = 1,
        Cost = 0M,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
    };

    public static CreateTreatmentListItemDto CreateDummy => new Faker<CreateTreatmentListItemDto>()
        .RuleFor(x => x.ItemName, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.ItemBrand, f => C4WX1Faker.ShortString)
        .RuleFor(x => x.TListTypeID_FK, f => 1)
        .RuleFor(x => x.Cost, f => f.Random.Decimal())
        .RuleFor(x => x.StartDate, f => DateTime.Now)
        .RuleFor(x => x.EndDate, f => DateTime.Now)
        .Generate();

    public static UpdateTreatmentListItemDto UpdateDto(int? id = null) => new()
    {
        Id = id ?? C4WX1Faker.Id,
        ItemName = "updated-control-ItemName",
        ItemBrand = "updated-control-ItemBrand",
        TListTypeID_FK = 1,
        Cost = 10M,
        StartDate = DateTime.Now,
        EndDate = DateTime.Now,
    };
}
