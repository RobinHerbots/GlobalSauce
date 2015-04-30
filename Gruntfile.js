module.exports = function (grunt) {
    var nuspecs = grunt.file.expand(["nuspecs/*.nuspec"]);

    // Project configuration.
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        bump: {
            options: {
                files: ['package.json'],
                updateConfigs: ['pkg'],
                commit: false,
                createTag: false,
                push: false
            }
        },
		release: {
            options: {
                bump: false,
				npm: false,
                commitMessage: 'Globalsauce <%= version %>'
            }
        },
        nugetpack: {
            dist: {
                src: nuspecs,
                dest: 'dist/',
                options: {
                    version: '<%= pkg.version %>'
                }
            }
        },
        nugetpush: {
            nupkg: {
                src: "dist/*.nupkg"
            }
        },
        clean: ["dist"],
        shell: {
            options: {
                stderr: false,
                execOptions: {
                    maxBuffer: Infinity
                }
            },
            build: {
                command: ['msbuild GlobalSauce.sln /t:clean', 'msbuild GlobalSauce.sln /t:rebuild /p:Configuration=Release'].join("&&")
            },
            gitcommitchanges: {
                command: ['git add .',
                    'git reset -- package.json',
                    'git commit -m "Globalsauce <%= pkg.version %>"'
                ].join('&&')
            }
        }
    });

    // Load the plugin that provides the tasks.
    grunt.loadNpmTasks('grunt-bump');
    grunt.loadNpmTasks('grunt-nuget');
	grunt.loadNpmTasks('grunt-release');
    grunt.loadNpmTasks('grunt-shell');
    grunt.loadNpmTasks('grunt-contrib-clean');

    // Default task(s).
	grunt.registerTask('publish:patch', ['clean', 'bump:patch', 'updateversion', 'shell:build', 'shell:gitcommitchanges', 'release', 'nugetpack', 'nugetpush']);
    grunt.registerTask('publish:minor', ['clean', 'bump:minor', 'updateversion', 'shell:build', 'shell:gitcommitchanges', 'release', 'nugetpack', 'nugetpush']);
    grunt.registerTask('publish:major', ['clean', 'bump:major', 'updateversion', 'shell:build', 'shell:gitcommitchanges', 'release', 'nugetpack', 'nugetpush']);
	
    grunt.registerTask('default', ['shell:build']);
    grunt.registerTask('updateversion', "Update versions", function () {
        var pkgJson = require('./package.json');

        var assemblyInfos = grunt.file.expand(["**/AssemblyInfo.cs"]);

        for (var i = 0; i < assemblyInfos.length; i++) {
            var assi = grunt.file.read(assemblyInfos[i]);

            assi = assi.replace(/\[assembly: AssemblyVersion\("[^\*^"]*"\)\]/g, "[assembly: AssemblyVersion(\"" + pkgJson.version + ".0" + "\")]");
            assi = assi.replace(/\[assembly: AssemblyFileVersion\(".*"\)\]/g, "[assembly: AssemblyFileVersion(\"" + pkgJson.version + ".0" + "\")]");
            grunt.file.write(assemblyInfos[i], assi);
            console.log(assemblyInfos[i] + " set to version " + pkgJson.version);
        }
        for (i = 0; i < nuspecs.length; i++) {
            var nuspec = grunt.file.read(nuspecs[i]);

            nuspec = nuspec.replace(/<version>.*<\/version>/, "<version>" + pkgJson.version + "</version>");
            grunt.file.write(nuspecs[i], nuspec);
            console.log(nuspecs[i] + " set to version " + pkgJson.version);
        }
    });

};