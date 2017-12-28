/* ------------------------------------------------------------------------------
 *
 *  # Gulp file
 *
 *  Basic Gulp tasks for Limitless template
 *
 *  Version: 1.1
 *  Latest update: Aug 20, 2016
 *
 * ---------------------------------------------------------------------------- */


// Include gulp
var gulp = require('gulp'); 


// Include our plugins
var jshint = require('gulp-jshint');
var less = require('gulp-less');
var minifyCss = require('gulp-clean-css');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var rename = require('gulp-rename');


// Lint task
gulp.task('lint', function() {
    return gulp
        .src('assets/js/core/app.js')                 // lint core JS file. Or specify another path
        .pipe(jshint())
        .pipe(jshint.reporter('default'));
});


// Compile less files of a full version
gulp.task('less_full', function() {
    return gulp
        .src('assets/less/_main_full/*.less')         // locate /less/ folder root to grab 4 main files
        .pipe(less())                                 // compile
        .pipe(gulp.dest('wwwroot/css/'))                // destination path for normal CSS
        .pipe(minifyCss({                             // minify CSS
            keepSpecialComments: 0                    // remove all comments
        }))
        .pipe(rename({                                // rename file
            suffix: ".min"                            // add *.min suffix
        }))
        .pipe(gulp.dest('wwwroot/css'));               // destination path for minified CSS
});


// Compile less files of starter kit
gulp.task('less_starters', function() {
    return gulp
        .src('assets/less/_main_starters/*.less')     // locate /less/ folder root to grab 4 main files
        .pipe(less())                                 // compile
        .pipe(gulp.dest('wwwroot/css'))       // destination path for normal CSS
        .pipe(minifyCss({                             // minify CSS
            keepSpecialComments: 0                    // remove all comments
        }))
        .pipe(rename({                                // rename file
            suffix: ".min"                            // add *.min suffix
        }))
        .pipe(gulp.dest('wwwroot/css'));      // destination path for minified CSS
});


// Concatenate & minify JS (uncomment if you want to use)
gulp.task('concatenate', function() {
    return gulp
        .src('assets/js/*.js')                        // path to js files you want to concat
        .pipe(concat('all.js'))                       // output file name
        .pipe(gulp.dest('wwwroot/js1'))                 // destination path for normal JS
        .pipe(rename({                                // rename file
            suffix: ".min"                            // add *.min suffix
        }))
        .pipe(uglify())                               // compress JS
        .pipe(gulp.dest('wwwroot/js2'));                // destination path for minified JS
});


// Minify template's core JS file
gulp.task('minify_core', function() {
    return gulp
        .src('assets/js/core/app.js')                 // path to app.js file
        .pipe(uglify())                               // compress JS
        .pipe(rename({                                // rename file
            suffix: ".min"                            // add *.min suffix
        }))
        .pipe(gulp.dest('wwwroot/js/core'));          // destination path for minified file
});


// Watch files for changes
gulp.task('watch', function() {
    gulp.watch('assets/js/core/app.js', [             // listen for changes in app.js file and automatically compress
        'lint',                                       // lint
        'concatenate',                              // concatenate & minify JS files (uncomment if in use)
        'minify_core'                                 // compress app.js
    ]); 
    gulp.watch('assets/less/**/*.less', ['less_full', 'less_starters']);    // listen for changes in all LESS files and automatically re-compile
});


// Default task
gulp.task('default', [                                // list of default tasks
    'lint',                                           // lint
    'less_full',                                      // full version less compile
    'less_starters',                                  // starter kit less compile
    'concatenate',                                  // uncomment if in use
    'minify_core',                                    // compress app.js
    'watch'                                           // watch for changes
]);


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
gulp.src('./node_modules/jquery-mask-plugin/dist/*.js').pipe(gulp.dest('./wwwroot/script/jquery-mask-plugin/'));
    gulp.src('./node_modules/bootstrap-datepaginator/dist/*').pipe(gulp.dest('./wwwroot/script/'));
    gulp.src('./node_modules/bootstrap-datepicker/dist/js/*').pipe(gulp.dest('./wwwroot/script/'));
    
    gulp.src('./node_modules/icomoon/style.css').pipe(gulp.dest('./wwwroot/css/icomoon/'));
    gulp.src('./node_modules/icomoon/fonts/*').pipe(gulp.dest('./wwwroot/css/icomoon/fonts/'));

});