﻿/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('copy-files', function () {

    gulp.src('./node_modules/angular/angular.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-animate/angular-animate.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-aria/angular-aria.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-cookies/angular-cookies.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-loader/angular-loader.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-loading-bar/build/loading-bar.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-message-format/angular-message-format.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-messages/angular-messages.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-parse-ext/angular-parse-ext.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-resource/angular-resource.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-route/angular-route.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-sanitize/angular-sanitize.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/angular-scenario/angular-scenario.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));

    gulp.src('./node_modules/bootstrap/dist/js/bootstrap.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/bootstrap/dist/css/bootstrap.min.css').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/bootstrap/dist/css/bootstrap-theme.min.css').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.eot').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.svg').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.ttf').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.woff').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/bootstrap/dist/fonts/glyphicons-halflings-regular.woff2').pipe(gulp.dest('./wwwroot/node_modules/'));

    gulp.src('./node_modules/jquery/dist/jquery.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/toastr/build/toastr.min.css').pipe(gulp.dest('./wwwroot/node_modules/'));
    gulp.src('./node_modules/toastr/build/toastr.min.js').pipe(gulp.dest('./wwwroot/node_modules/'));

gulp.src('./node_modules/icomoon/style.js').pipe(gulp.dest('./wwwroot/node_modules/icomoon/'));

});