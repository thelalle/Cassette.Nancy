using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace Cassette.Nancy.Demo.TinyIoC {
    public class Bootstrapper : DefaultNancyBootstrapper {
        public Bootstrapper() {
            CassetteNancyStartup.OptimizeOutput = false;
        }

        protected override void ApplicationStartup(TinyIoCContainer container, global::Nancy.Bootstrapper.IPipelines pipelines) {
            base.ApplicationStartup(container, pipelines);

            Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Images"));
        }
    }
}