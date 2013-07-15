using System;
using System.Diagnostics;
using Nancy;
using Nancy.Conventions;
using Nancy.Testing.Fakes;
using Nancy.TinyIoc;

namespace Cassette.Nancy.Test {
    public class NonOptimizingBootstrapper : DefaultNancyBootstrapper {
        public NonOptimizingBootstrapper() {
            CassetteNancyStartup.OptimizeOutput = false;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container) {
            base.ConfigureApplicationContainer(container);

            FakeRootPathProvider.RootPath = Utility.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..");
            Debug.WriteLine(FakeRootPathProvider.RootPath);
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions) {
            base.ConfigureConventions(nancyConventions);

            Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Images"));
        }
    }
}