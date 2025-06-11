using C4WX1.API.Features.Activity.Repository;
using C4WX1.API.Features.Branch.Repository;
using C4WX1.API.Features.CarePlanSubGoal.Repository;
using C4WX1.API.Features.Chat.Repository;
using C4WX1.API.Features.CPGoals.Repository;
using C4WX1.API.Features.ExternalDoctor.Repositories;
using C4WX1.API.Features.Generator;
using C4WX1.API.Features.Intervention.Repository;
using C4WX1.API.Features.NutritionTaskReference.Repository;
using C4WX1.API.Features.ProblemList.Repository;
using C4WX1.API.Features.RecentView.Repository;
using C4WX1.API.Features.Security;
using C4WX1.API.Features.Skillset.Repository;
using C4WX1.API.Features.SysConfig.Repository;
using C4WX1.API.Features.VisitAndBillingReport.Repository;
using C4WX1.API.Features.WoundReport.Repository;

namespace C4WX1.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services
            .AddTransient<IActivityRepository, ActivityRepository>()
            .AddTransient<IBranchRepository, BranchRepository>()
            .AddTransient<ICarePlanSubGoalRepository, CarePlanSubGoalRepository>()
            .AddTransient<IChatRepository, ChatRepository>()
            .AddTransient<ICPGoalsRepository, CPGoalsRepository>()
            .AddTransient<IExternalDoctorRepository, ExternalDoctorRepository>()
            .AddTransient<IInterventionRepository, InterventionRepository>()
            .AddTransient<INutritionTaskReferenceRepository, NutritionTaskReferenceRepository>()
            .AddTransient<IProblemListRepository, ProblemListRepository>()
            .AddTransient<IRecentViewRepository, RecentViewRepository>()
            .AddTransient<ISkillsetRepository, SkillsetRepository>()
            .AddTransient<ISysConfigRepository, SysConfigRepository>()
            .AddTransient<IWoundReportRepository, WoundReportRepository>()
            .AddTransient<IVisitRepository, VisitRepository>()
            .AddTransient<ISecurityService, SecurityService>()
            .AddTransient<IPasswordGenerator, PasswordGenerator>();

        return services;
    }
}
