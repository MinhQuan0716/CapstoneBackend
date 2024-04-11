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
             sshagent(['ssh-access']) {
              sh  ./helloworld.sh
          }
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
