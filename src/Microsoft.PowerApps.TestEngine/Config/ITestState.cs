﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.Extensions.Logging;
using Microsoft.PowerApps.TestEngine.Modules;
using Microsoft.PowerApps.TestEngine.Providers;
using Microsoft.PowerApps.TestEngine.Users;

namespace Microsoft.PowerApps.TestEngine.Config
{
    /// <summary>
    /// State of the test run
    /// </summary>
    public interface ITestState
    {
        /// <summary>
        /// The current test provider
        /// </summary>
        public ITestWebProvider TestProvider { get; set; }

        /// <summary>
        /// Parses and sets up the test state.
        /// </summary>
        /// <param name="testConfigFile">Config file for test</param>
        /// <param name="logger">Logger</param>
        public void ParseAndSetTestState(string testConfigFile, ILogger logger);

        /// <summary>
        /// Gets the test suite defined for the test run.
        /// </summary>
        /// <returns>The test suite for test</returns>
        public TestSuiteDefinition GetTestSuiteDefinition();

        /// <summary>
        /// Gets all the test cases defined for the test run.
        /// </summary>
        /// <returns>List of test cases</returns>
        public List<TestCase> GetTestCases();

        /// <summary>
        /// Set the environment id the apps should be opened in.
        /// </summary>
        /// <param name="environmentId">Environment id</param>
        public void SetEnvironment(string environmentId);

        /// <summary>
        /// Gets the environment id the apps should be opened in.
        /// </summary>
        /// <returns>Environment id</returns>
        public string GetEnvironment();

        /// <summary>
        /// Set the domain of the URL where the app will be launched
        /// </summary>
        /// <param name="domain">Domain</param>
        public void SetDomain(string domain);

        /// <summary>
        /// Gets the domain of the URL where the app will be launched
        /// </summary>
        /// <returns>Domain</returns>
        public string GetDomain();

        /// <summary>
        /// Sets the tenant the app should be opened in.
        /// </summary>
        /// <param name="tenantId">Tenant id</param>
        public void SetTenant(string tenantId);

        /// <summary>
        /// Gets the tenant the app should be opened in.
        /// </summary>
        /// <returns>Tenant id</returns>
        public string GetTenant();

        /// <summary>
        /// Sets the directory that all test outputs should be placed in.
        /// </summary>
        /// <param name="outputDirectory">Output directory</param>
        public void SetOutputDirectory(string outputDirectory);


        /// <summary>
        /// Sets the test config file
        /// </summary>
        /// <param name="testConfigFile">The test config file</param>
        public void SetTestConfigFile(FileInfo testConfigFile);

        /// <summary>
        /// Gets the test config file
        /// </summary>
        /// <returns>Test config file</returns>
        public FileInfo GetTestConfigFile();

        /// <summary>
        /// Gets the directory that all tests outputs should be placed in.
        /// </summary>
        /// <returns>Output directory</returns>
        public string GetOutputDirectory();

        /// <summary>
        /// Gets the user configuration given a persona.
        /// </summary>
        /// <param name="persona">Persona</param>
        /// <returns>User configuration</returns>
        public UserConfiguration GetUserConfiguration(string persona);

        /// <summary>
        /// Gets the test settings.
        /// </summary>
        /// <returns>Gets the test settings</returns>
        public TestSettings GetTestSettings();

        /// <summary>
        /// Gets the timeout value from the test settings.
        /// </summary>
        /// <returns>The timeout value</returns>
        public int GetTimeout();

        /// <summary>
        /// Loads any matching Test Engine Modules
        /// </summary>
        public void LoadExtensionModules(ILogger logger);

        /// <summary>
        /// Sets path to locate option extension modules
        /// </summary>
        /// <param name="path">The path to set</param>
        public void SetModulePath(string path);

        /// <summary>
        /// Add optional test engine modules
        /// </summary>
        /// <param name="modules"></param>
        public void AddModules(IEnumerable<ITestEngineModule> modules);

        /// <summary>
        /// Get the list of registered Test engine extension models
        /// </summary>
        /// <param name="modules"></param>
        public List<ITestEngineModule> GetTestEngineModules();

        /// <summary>
        /// Get the list of registered Test engine user managers
        /// </summary>
        public List<IUserManager> GetTestEngineUserManager();

        /// <summary>
        /// Get the list of registered Test engine web test providers
        /// </summary>
        public List<ITestWebProvider> GetTestEngineWebProviders();

        public List<IUserCertificateProvider> GetTestEngineAuthProviders();

        /// <summary>
        /// Determine if the steps of the test steps should be executed step by step or as one action
        /// </summary>
        public bool ExecuteStepByStep { get; set; }

        /// <summary>
        /// Event triggered before a test step is executed
        /// </summary>
        event EventHandler<TestStepEventArgs> BeforeTestStepExecuted;

        /// <summary>
        /// Event triggered after a test step is executed
        /// </summary>
        event EventHandler<TestStepEventArgs> AfterTestStepExecuted;

        /// <summary>
        /// This method is called before a test step is executed.
        /// It allows for any necessary setup or logging before the test step runs.
        /// </summary>
        /// <param name="e">The event arguments containing details about the test step.</param>
        public void OnBeforeTestStepExecuted(TestStepEventArgs e);

        /// <summary>
        /// This method is called after a test step is executed.
        /// It allows for any necessary cleanup or logging after the test step runs.
        /// </summary>
        /// <param name="e">The event arguments containing details about the test step.</param>
        public void OnAfterTestStepExecuted(TestStepEventArgs e);

        /// <summary>
        /// Indicate that this test run should be a record mode not execution
        /// </summary>
        void SetRecordMode();
    }
}
