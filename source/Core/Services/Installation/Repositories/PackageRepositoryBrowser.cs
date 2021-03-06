using System;
using System.Collections.Generic;
using System.Linq;

using NuDeploy.Core.Common;

using NuGet;

namespace NuDeploy.Core.Services.Installation.Repositories
{
    public class PackageRepositoryBrowser : IPackageRepositoryBrowser
    {
        private readonly IPackageRepository[] repositories;

        private readonly SourceRepositoryConfiguration[] repositoryConfigurations;

        public PackageRepositoryBrowser(ISourceRepositoryProvider sourceRepositoryProvider, IPackageRepositoryFactory packageRepositoryFactory)
        {
            if (sourceRepositoryProvider == null)
            {
                throw new ArgumentNullException("sourceRepositoryProvider");
            }

            if (packageRepositoryFactory == null)
            {
                throw new ArgumentNullException("packageRepositoryFactory");
            }

            this.repositoryConfigurations = sourceRepositoryProvider.GetRepositoryConfigurations().ToArray();
            this.repositories = this.repositoryConfigurations.Select(r => packageRepositoryFactory.CreateRepository(r.Url.ToString())).ToArray();
        }

        public IEnumerable<SourceRepositoryConfiguration> RepositoryConfigurations
        {
            get
            {
                return this.repositoryConfigurations;
            }
        }

        public IPackage FindPackage(string packageId)
        {
            if (string.IsNullOrWhiteSpace(packageId))
            {
                throw new ArgumentException("packageId");
            }

            return this.repositories.Select(repository => repository.FindPackage(packageId)).FirstOrDefault(package => package != null);
        }
    }
}