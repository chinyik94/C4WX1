﻿using C4WX1.API.Features.Shared.Constants;

namespace C4WX1.Tests.Shared;

public class C4WX1State : StateFixture
{
    public int CreateCount => C4WX1Faker.CreateCount;
    public int DefaultPageSize => PaginationDefaults.Size;
    public int LowPageSize => 5;
    public int HighPageSize => 100;
    public string DefaultDescOrderby => "test desc";
    public string DefaultAscOrderby => "test asc";
}
