using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using ItAcademy.Project.Music.Client.Interfaces.PresentationServices;
using ItAcademy.Project.Music.Client.PresentationServices;
using ItAcademy.Project.Music.Client.PresentationServices.Interfaces;
using ItAcademy.Project.Music.Data.Context;
using ItAcademy.Project.Music.Data.Repository;
using ItAcademy.Project.Music.Data.UnitOfWork;
using ItAcademy.Project.Music.Domain.DomainServices;
using ItAcademy.Project.Music.Domain.DomainServices.Interfaces;
using ItAcademy.Project.Music.Domain.Repositories;
using ItAcademy.Project.Music.Domain.UnitOfWork;

namespace ItAcademy.Project.Music.Client.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<MusDbContext>().As<IMusDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<TrackDomainService>().As<ITrackDomainService>().InstancePerDependency();
            builder.RegisterType<TrackPresentationService>().As<ITrackPresentationService>().InstancePerDependency();
            builder.RegisterType<ArtistPresentationService>().As<IArtistPresentationService>().InstancePerDependency();
            builder.RegisterType<ArtistRepository>().As<IArtistRepository>().InstancePerDependency();
            builder.RegisterType<AlbumRepository>().As<IAlbumRepository>().InstancePerDependency();
            builder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerDependency();
            builder.RegisterType<TrackRepository>().As<ITrackRepository>().InstancePerDependency();
            builder.RegisterType<ArtistDomainService>().As<IArtistDomainService>().InstancePerDependency();
            builder.RegisterType<AlbumDomainService>().As<IAlbumDomainService>().InstancePerDependency();
            builder.RegisterType<GenreDomainService>().As<IGenreDomainService>().InstancePerDependency();
            builder.RegisterType<AppUserRepository>().As<IAppUserRepository>().InstancePerDependency();
            builder.RegisterType<AppUserDomainService>().As<IAppUserDomainService>().InstancePerDependency();
            builder.RegisterType<PlaylistRepository>().As<IPlaylistRepository>().InstancePerDependency();
            builder.RegisterType<PlaylistDomainService>().As<IPlaylistDomainService>().InstancePerDependency();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            FluentValidationModelValidatorProvider.Configure(config =>
            {
                config.ValidatorFactory = new AutofacValidatorFactory(container);
            });
        }
    }
}