using System.Collections.Generic;
using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV5s;

namespace FlutterWave.Core.Infrastructure.Build
{




    internal class Program
    {
        private static void Main(string[] args)
        {
            var adoNetClient = new ADotNetClient();

            var githubPipeline = new GithubPipeline
            {
                Name = "FlutterWave.Core Build",


                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Dictionary<string, Job>
                {
                    ["build"] = new Job
                    {
                        EnvironmentVariables = new Dictionary<string, string>
                        {
                            { "ApiKey", "${{ secrets.APIKEY }}" },
                            { "EncryptionKey", "${{ secrets.ENCRYPTIONKEY }}" }
                        },

                        RunsOn = BuildMachines.WindowsLatest,

                        Steps = new List<GithubTask>
                        {
                            new CheckoutTaskV5
                            {
                                Name = "Pulling Code"
                            },

                            new SetupDotNetTaskV5
                            {
                                Name = "Installing .NET",

                                With = new TargetDotNetVersionV5
                                {
                                    DotNetVersion = "10.0.401"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restoring Packages"
                            },

                            new DotNetBuildTask
                            {
                                Name = "Building Solution"
                            },

                            new TestTask
                            {
                                Name = "Running Tests"
                            }
                        }
                    }
                }
            };


            adoNetClient.SerializeAndWriteToFile(
                adoPipeline: githubPipeline,
                path: "../../../../.github/workflows/dotnet.yml");

        }
    }
}