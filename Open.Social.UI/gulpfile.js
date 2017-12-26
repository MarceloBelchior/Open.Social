/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

gulp.task('copy-files', function () {

    gulp.src('./node_modules/angular/angular.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-animate/angular-animate.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-aria/angular-aria.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-cookies/angular-cookies.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-loader/angular-loader.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-loading-bar/build/loading-bar.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-message-format/angular-message-format.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-messages/angular-messages.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-parse-ext/angular-parse-ext.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-resource/angular-resource.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-route/angular-route.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-sanitize/angular-sanitize.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/angular-scenario/angular-scenario.min.js').pipe(gulp.dest('./wwwroot/script/'));

    gulp.src('./node_modules/bootstrap/dist/js/bootstrap.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/bootstrap/dist/css/*.css').pipe(gulp.dest('./wwwroot/css/bootstrap/'));
    gulp.src('./node_modules/bootstrap/dist/fonts/*').pipe(gulp.dest('./wwwroot/css/bootstrap/fonts/'));

    gulp.src('./node_modules/jquery/dist/jquery.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/toastr/build/toastr.min.css').pipe(gulp.dest('./wwwroot/css/toastr/'));
    gulp.src('./node_modules/toastr/build/toastr.min.js').pipe(gulp.dest('./wwwroot/script/'));

    gulp.src('./node_modules/drilldown/dist/drilldown.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/nicescroll/dist/jquery.nicescroll.min.js').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/nicescroll/dist/zoomico.png').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/jquery.cookie/jquery.cookie.js').pipe(gulp.dest('./wwwroot/script/'));
    
    gulp.src('./node_modules/icomoon/style.css').pipe(gulp.dest('./wwwroot/css/icomoon/'));
    gulp.src('./node_modules/icomoon/fonts/*').pipe(gulp.dest('./wwwroot/css/icomoon/fonts/'));

});