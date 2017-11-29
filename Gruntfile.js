module.exports = function(grunt) {
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
    availabletasks: {
      tasks: {
        options: {
          filter: 'exclude',
          tasks: ['availabletasks', 'default'],
          showTasks: ['user']
        }
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
      dist: {
        src: "dist/*.nupkg"
      }
    },
    clean: ["dist"],
    msbuild: {
      debug: {
        src: ['GlobalSauce.sln'],
        options: {
          projectConfiguration: 'Debug',
          targets: ['Clean', 'Rebuild'],
          version: 15.0,
          maxCpuCount: 4,
          buildParameters: {
            WarningLevel: 2
          },
          verbosity: 'quiet'
        }
      },
      release: {
        src: ['GlobalSauce.sln'],
        options: {
          projectConfiguration: 'Release',
          targets: ['Clean', 'Rebuild'],
          version: 14.0,
          maxCpuCount: 4,
          buildParameters: {
            WarningLevel: 2
          },
          verbosity: 'quiet'
        }
      }
    },
    shell: {
      options: {
        stderr: false,
        execOptions: {
          maxBuffer: Infinity
        }
      },
      gitcommitchanges: {
        command: ['git add .',
          'git reset -- package.json',
          'git commit -m "Globalsauce <%= pkg.version %>"'
        ].join('&&')
      }
    }
  });

  require('load-grunt-tasks')(grunt);

  // Default task(s).
  grunt.registerTask('default', ['availabletasks']);
  grunt.registerTask('publish:patch', ['clean', 'bump:patch', 'updateversion', 'msbuild:release', 'shell:gitcommitchanges', 'release', 'nugetpack', 'nugetpush']);
  grunt.registerTask('publish:minor', ['clean', 'bump:minor', 'updateversion', 'msbuild:release', 'shell:gitcommitchanges', 'release', 'nugetpack', 'nugetpush']);
  grunt.registerTask('publish:major', ['clean', 'bump:major', 'updateversion', 'msbuild:release', 'shell:gitcommitchanges', 'release', 'nugetpack', 'nugetpush']);

  grunt.registerTask('updateversion', "Update versions", function() {
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
