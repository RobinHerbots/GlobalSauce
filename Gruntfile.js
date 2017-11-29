var sep = require('path').sep;

module.exports = function (grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON("package.json"),
        bump: {
            options: {
                files: ['package.json'],
                updateConfigs: ['pkg'],
                commit: true,
                createTag: true,
                push: true,
                pushTo: 'origin'
            }
        },
        msbuild: {
            release: {
                src: ['src/GlobalSauce.sln'],
                options: {
                    projectConfiguration: 'Release',
                    targets: ['Clean', 'Rebuild'],
                    buildParameters: {
                        OutputPath: process.cwd() + sep + "build",
                        WarningLevel: 2,
                        FileVersion: '<%= pkg.version %>',
                        Version: '<%= pkg.version %>',
                        AssemblyVersion: '<%= pkg.version %>'
                    },
                }
            }
        },
        nugetpack: {
            dist: {
                src: function () {
                    return 'nuspecs/GlobalSauce.nuspec';
                }(),
                dest: 'build/',
                options: {
                    version: '<%= pkg.version %>'
                }
            }
        },
        nugetpush: {
            dist: {
                src: 'build/GlobalSauce.<%= pkg.version %>.nupkg',
                options: {
                    source: "https://www.nuget.org"
                }
            },
        },
        availabletasks: {
            tasks: {
                options: {
                    filter: 'exclude',
                    tasks: ['availabletasks', 'default'],
                    showTasks: ['user']
                }
            }
        }
    });

// Load the plugin that provides the tasks.
    require('load-grunt-tasks')(grunt);
    grunt.registerTask('Publish', ["bump", "msbuild", "nugetpack", "nugetpush"]);
    grunt.registerTask('default', ["availabletasks"]);
};