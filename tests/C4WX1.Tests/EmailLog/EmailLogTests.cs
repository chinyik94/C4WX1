using C4WX1.API.Features.EmailLog.Constants;
using C4WX1.API.Features.EmailLog.Dtos;
using C4WX1.API.Features.EmailLog.Endpoints;
using C4WX1.API.Features.Shared.Constants;
using C4WX1.Tests.Shared;

namespace C4WX1.Tests.EmailLog;

[Collection<C4WX1TestCollection>]
public class EmailLogTests(C4WX1App app, C4WX1State state) : TestBase
{
    private CreateEmailLogDto Control => new()
    {
        msgBCC = "control-msgBcc",
        msgCC = "control-msgcc",
        msgTo = "control-msgTo",
        msgSubj = "control-msgSub",
        msgBody = "control-msgBody",
        msgFromName = "control-msgFromName",
        msgFrom = "control-msgFrom",
        isHtml = false,
        attachmentName = "control-attachmentName",
        isSent = false,
        smtpLogin = "control-smtpLogin",
        smtpPassword = "control-smtpPassword",
        smtpPort = "control-smtpPort",
        smtpServerAddress = "control-smtpServerAddress"
    };

    private async Task SetupAsync(CreateEmailLogDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateEmailLogDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
    }

    private async Task CleanupAsync()
    {
        await using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "EmailLog" CASCADE;
            """);
    }

    [Fact]
    public async Task Create()
    {
        var (resp, res) = await app.Client.POSTAsync<Create, CreateEmailLogDto, int>(
            Control);

        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount()
    {
        var expectedCount = state.CreateCount;
        var dummies = Enumerable.Range(0, expectedCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        res.ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithControlMsgFrom()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                MsgFrom = Control.msgFrom,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        res.ShouldBe(controls.Count());

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithControlMsgFromName()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                MsgFromName = Control.msgFromName,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        res.ShouldBe(controls.Count());

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithControlMsgTo()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                MsgTo = Control.msgTo,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        res.ShouldBe(controls.Count());

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithControlMsgSubj()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                MsgSubj = Control.msgSubj,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        res.ShouldBe(controls.Count());

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithControlData_ButOutsideOfDateRange()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                MsgSubj = Control.msgSubj,
                FromDate = DateTime.Now.AddDays(-10),
                ToDate = DateTime.Now.AddDays(-9)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBe(0);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithIsSentTrue()
    {
        var expectedCount = 0;
        for (int i = 0; i < state.CreateCount; i++)
        {
            var dummy = EmailLogFaker.CreateDummy;
            await SetupAsync(dummy);
            if (dummy.isSent ?? false)
            {
                expectedCount++;
            }
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                IsSent = "true",
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        res.ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetCount_WithIsSentFalse()
    {
        var expectedCount = 0;
        for (int i = 0; i < state.CreateCount; i++)
        {
            var dummy = EmailLogFaker.CreateDummy;
            await SetupAsync(dummy);
            if (!(dummy.isSent ?? false))
            {
                expectedCount++;
            }
        }

        var (resp, res) = await app.Client.GETAsync<GetCount, GetEmailLogCountDto, int>(
            new GetEmailLogCountDto
            {
                IsSent = "false",
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        res.ShouldBe(expectedCount);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList()
    {
        var createCount = state.CreateCount;
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithControlMsgFrom()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                MsgFrom = Control.msgFrom,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(controls.Count());
        res.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithControlMsgFromName()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                MsgFromName = Control.msgFromName,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(controls.Count());
        res.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithControlMsgTo()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                MsgTo = Control.msgTo,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(controls.Count());
        res.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithControlMsgSubj()
    {
        var controls = Enumerable.Range(0, 5)
            .Select(x => Control);
        foreach (var control in controls)
        {
            await SetupAsync(control);
        }
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                MsgSubj = Control.msgSubj,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(controls.Count());
        res.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithIsSent()
    {
        var dummies = Enumerable.Range(0, state.CreateCount)
            .Select(x => EmailLogFaker.CreateDummy);
        var trueCount = 0;
        var falseCount = 0;
        foreach (var dummy in dummies)
        {
            if (dummy.isSent ?? false)
            {
                trueCount++;
            } 
            else
            {
                falseCount++;
            }
            await SetupAsync(dummy);
        }

        var expectedTrueCount = Math.Min(trueCount, PaginationDefaults.Size);
        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                IsSent = "true",
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(expectedTrueCount);
        res.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        var expectedFalseCount = Math.Min(falseCount, PaginationDefaults.Size);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                IsSent = "false",
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBeGreaterThan(0);
        res2.Count().ShouldBe(expectedFalseCount);
        res2.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithPageSize()
    {
        var pageSize = state.LowPageSize;
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => EmailLogFaker.CreateDummy);
        var expectedCount = Math.Min(createCount, pageSize);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                PageSize = pageSize,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        var pageSize2 = state.HighPageSize;
        var expectedCount2 = Math.Min(createCount, pageSize2);
        var (resp2, res2) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                PageSize = pageSize2,
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1)
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBeGreaterThan(0);
        res2.Count().ShouldBe(expectedCount2);
        res2.Select(x => x.EmailLogId).ShouldBeInOrder(SortDirection.Descending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithCreatedDateOrderBy()
    {
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => EmailLogFaker.CreateDummy);
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1),
                OrderBy = $"{SortColumns.CreatedDate} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.CreatedDate).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1),
                OrderBy = $"{SortColumns.CreatedDate} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBeGreaterThan(0);
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.CreatedDate).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithMsgToOrderBy()
    {
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => EmailLogFaker.CreateDummy);
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1),
                OrderBy = $"{SortColumns.MsgTo} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.msgTo).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1),
                OrderBy = $"{SortColumns.MsgTo} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBeGreaterThan(0);
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.msgTo).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }

    [Fact]
    public async Task GetList_WithMsgSubjOrderBy()
    {
        var createCount = state.CreateCount;
        var dummies = Enumerable.Range(0, createCount)
            .Select(x => EmailLogFaker.CreateDummy);
        var expectedCount = Math.Min(createCount, PaginationDefaults.Size);
        foreach (var dummy in dummies)
        {
            await SetupAsync(dummy);
        }

        var (resp, res) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1),
                OrderBy = $"{SortColumns.MsgSubj} {SortDirections.Desc}"
            });
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.Count().ShouldBeGreaterThan(0);
        res.Count().ShouldBe(expectedCount);
        res.Select(x => x.msgSubj).ShouldBeInOrder(SortDirection.Descending);

        var (resp2, res2) = await app.Client.GETAsync<GetList, GetEmailLogListDto, IEnumerable<EmailLogDto>>(
            new GetEmailLogListDto
            {
                FromDate = DateTime.Now.AddDays(-1),
                ToDate = DateTime.Now.AddDays(1),
                OrderBy = $"{SortColumns.MsgSubj} {SortDirections.Asc}"
            });
        resp2.IsSuccessStatusCode.ShouldBeTrue();
        res2.Count().ShouldBeGreaterThan(0);
        res2.Count().ShouldBe(expectedCount);
        res2.Select(x => x.msgSubj).ShouldBeInOrder(SortDirection.Ascending);

        await CleanupAsync();
    }
}
