pipeline {
    agent any

     tools {
           dotnetsdk "7.0" // Name: 5.0, URL: (download URL for .NET SDK 5.0)
           }

    stages {
        stage ('Clean workspace') {
         steps {
          cleanWs()
       }
      }
        stage('Checkout') {
            steps {
                // Get some code from a GitHub repository
               git branch: 'main', credentialsId: 'githubtoken', url: 'https://github.com/MinhQuan0716/CapstoneBackend.git'
            }

            post {
                // If Maven was able to run the tests, even if some of the test
                // failed, record the test results and archive the jar file.
                success {
                   echo 'Pull code success'
                }
            }
        }
       
             stage('Build and Test') {
           steps {
              withDotNet(sdk: '7.0') { // Reference the tool by ID
            dotnetRestore 
             }
             }
            }
         stage('SSH server'){
           steps {
            sshPublisher(publishers: [sshPublisherDesc(configName: 'remote-server', transfers: [sshTransfer(cleanRemote: false, excludes: '', execCommand: './gitconfig.sh', execTimeout: 1200000000, flatten: false, makeEmptyDirs: false, noDefaultExcludes: false, patternSeparator: '[, ]+', remoteDirectory: '', remoteDirectorySDF: false, removePrefix: '', sourceFiles: 'redis.conf')], usePromotionTimestamp: false, useWorkspaceInPromotion: false, verbose: false)])

           }
            post {
                // Pull success
                success {
                   echo 'Push code to server success'
                }
           }
    }
 }
}
