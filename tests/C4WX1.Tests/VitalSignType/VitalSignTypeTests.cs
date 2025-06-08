using C4WX1.API.Features.Shared.Dtos;
using C4WX1.API.Features.VitalSignType.Dtos;
using C4WX1.API.Features.VitalSignType.Endpoints;
using C4WX1.Database.Models;
using Task = System.Threading.Tasks.Task;

namespace C4WX1.Tests.VitalSignType;

[Collection<C4WX1TestCollection>]
public class VitalSignTypeTests(C4WX1App app) : TestBase
{
    private async Task<int[]> SetupDependenciesAsync(int createCount = 1)
    {
        using var dbContext = app.CreateDbContext();
        var vitalSignTypes = Enumerable.Range(1, createCount)
            .Select(x => new VitalSignTypes
            {
                id = x,
                name = $"control-vitalSignType{x}"
            });
        await dbContext.VitalSignTypes.AddRangeAsync(vitalSignTypes, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
        return [.. vitalSignTypes.Select(x => x.id)];
    }

    private async Task<int> SetupAsync(CreateVitalSignTypeThresholdDto testData)
    {
        var (resp, res) = await app.Client.POSTAsync<CreateThreshold, CreateVitalSignTypeThresholdDto, int>(testData);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        return res;
    }

    private async Task CleanupAsync()
    {
        using var dbContext = app.CreateDbContext();
        await dbContext.Database.ExecuteSqlRawAsync("""
            TRUNCATE TABLE "VitalSignTypeThreshold", "VitalSignTypes" RESTART IDENTITY CASCADE;
            """, Cancellation);
        await dbContext.SaveChangesAsync(Cancellation);
    }

    [Fact]
    public async Task CreateThreshold()
    {
        var ids = await SetupDependenciesAsync();
        var (resp, res) = await app.Client.POSTAsync<CreateThreshold, CreateVitalSignTypeThresholdDto, int>(
            VitalSignTypeFaker.CreateDto(ids.First()));
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldBeGreaterThan(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task CreateThreshold_WithoutVitalSignType()
    {
        var (resp, res) = await app.Client.POSTAsync<CreateThreshold, CreateVitalSignTypeThresholdDto, int>(
            VitalSignTypeFaker.CreateDto());
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBe(0);
        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateThreshold()
    {
        var ids = await SetupDependenciesAsync();
        var id = await SetupAsync(VitalSignTypeFaker.CreateDto(ids.First()));
        var resp = await app.Client.PUTAsync<UpdateThreshold, UpdateVitalSignTypeThresholdDto>(
            VitalSignTypeFaker.UpdateDto(id));
        resp.IsSuccessStatusCode.ShouldBeTrue();
        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateThreshold_WithoutVitalSignType()
    {
        var resp = await app.Client.POSTAsync<UpdateThreshold, UpdateVitalSignTypeThresholdDto>(
            VitalSignTypeFaker.UpdateDto());
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task UpdateThreshold_WithNonExistentId()
    {
        await SetupDependenciesAsync();
        var resp = await app.Client.POSTAsync<UpdateThreshold, UpdateVitalSignTypeThresholdDto>(
            VitalSignTypeFaker.UpdateDto());
        resp.IsSuccessStatusCode.ShouldBeFalse();
        await CleanupAsync();
    }

    [Fact]
    public async Task GetThresholdById()
    {
        var ids = await SetupDependenciesAsync();
        var createDto = VitalSignTypeFaker.CreateDto(ids.First());
        var id = await SetupAsync(createDto);
        var req = C4WX1Faker.GetByIdDto(id);
        var (resp, res) = await app.Client.GETAsync<GetThresholdById, GetByIdDto, VitalSignTypeThresholdDto>(
            req);
        resp.IsSuccessStatusCode.ShouldBeTrue();
        res.ShouldNotBeNull();
        res.VitalSignTypeID_FK.ShouldBe(id);
        res.EwsMin1.ShouldBe(createDto.EwsMin1);
        res.EwsMin2.ShouldBe(createDto.EwsMin2);
        res.EwsMin3.ShouldBe(createDto.EwsMin3);
        res.EwsMin4.ShouldBe(createDto.EwsMin4);
        res.EwsMin5.ShouldBe(createDto.EwsMin5);
        res.EwsMin6.ShouldBe(createDto.EwsMin6);
        res.EwsMin7.ShouldBe(createDto.EwsMin7);
        res.EwsMax1.ShouldBe(createDto.EwsMax1);
        res.EwsMax2.ShouldBe(createDto.EwsMax2);
        res.EwsMax3.ShouldBe(createDto.EwsMax3);
        res.EwsMax4.ShouldBe(createDto.EwsMax4);
        res.EwsMax5.ShouldBe(createDto.EwsMax5);
        res.EwsMax6.ShouldBe(createDto.EwsMax6);
        res.EwsMax7.ShouldBe(createDto.EwsMax7);
        await CleanupAsync();
    }

    [Fact]
    public async Task GetThresholdById_WithNonExistentId()
    {
        var ids = await SetupDependenciesAsync();
        var createDto = VitalSignTypeFaker.CreateDto(ids.First());
        var id = await SetupAsync(createDto);
        var req = C4WX1Faker.GetByIdDto();
        var (resp, res) = await app.Client.GETAsync<GetThresholdById, GetByIdDto, VitalSignTypeThresholdDto>(
            req);
        resp.IsSuccessStatusCode.ShouldBeFalse();
        res.ShouldBeNull();
        await CleanupAsync();
    }
}
