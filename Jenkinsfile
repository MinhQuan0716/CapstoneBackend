pipeline {
    agent any

    

    stages {
        stage('Build') {
            steps {
                // Get some code from a GitHub repository
               checkout scmGit(branches: [[name: '*/main']], extensions: [], userRemoteConfigs: [[credentialsId: 'githubtoken', url: 'https://github.com/MinhQuan0716/CapstoneBackend.git']])

               
            }

            post {
                // If Maven was able to run the tests, even if some of the test
                // failed, record the test results and archive the jar file.
                success {
                   echo 'Pull code succesuccess'
                }
            }
        }
         stage('SSH server'){
           steps {
               sshPublisher(publishers: [sshPublisherDesc(configName: 'remote-server', transfers: [sshTransfer(cleanRemote: false, excludes: '', execCommand: '''cd CapstoneProject
              docker-compose up -d''', execTimeout: 120000, flatten: false, makeEmptyDirs: false, noDefaultExcludes: false, patternSeparator: '[, ]+', remoteDirectory: '', remoteDirectorySDF: false, removePrefix: '', sourceFiles: 'CapstoneProject')], usePromotionTimestamp: false, useWorkspaceInPromotion: false, verbose: false)])
           }
            post {
                // If Maven was able to run the tests, even if some of the test
                // failed, record the test results and archive the jar file.
                success {
                   echo 'Push code to server success'
                }
           }
    }
 }
}
