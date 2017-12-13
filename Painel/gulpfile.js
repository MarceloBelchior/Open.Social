/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('copy-files', function () {

    gulp.src('./node_modules/angular/angular.min.js')
        .pipe(gulp.dest('./wwwroot/npm/'));

});