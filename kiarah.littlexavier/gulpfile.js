/// <binding BeforeBuild='default' />
/// <vs BeforeBuild='default' />
///
// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var minifyCSS = require('gulp-minify-css');
var copy = require('gulp-copy');
var bower = require('gulp-bower');
var sourcemaps = require('gulp-sourcemaps');

var config = {
    //JavaScript files that will be combined into a jquery bundle
    jquerysrc: [
        'bower_components/jquery/dist/jquery.min.js',
        'bower_components/jquery-validation/dist/jquery.validate.min.js',
        'bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js'
    ],
    jquerybundle: 'Scripts/jquery-bundle.min.js',

    //JavaScript files that will be combined into a Bootstrap bundle
    bootstrapsrc: [
        'bower_components/bootstrap/dist/js/bootstrap.min.js',
        'bower_components/respond-minmax/dest/respond.min.js'
    ],
    bootstrapbundle: 'Scripts/bootstrap-bundle.min.js',

    //Modernizr
    modernizrsrc: ['bower_components/modernizr/modernizr.js'],
    modernizrbundle: 'Scripts/modernizer.min.js',

    //Angular
    angularsrc: [
        'bower_components/angular/angular.min.js',
        'bower_components/angular-resource/angular-resource.min.js',
        'bower_components/angular-route/angular-route.min.js',
        'bower_components/angular-local-storage/dist/angular-local-storage.min.js',
        'bower_components/angular-loading-bar/build/loading-bar.min.js',
        'bower_components/textAngular/dist/textAngular-rangy.min.js',
        'bower_components/textAngular/dist/textAngular-sanitize.min.js',
        'bower_components/textAngular/dist/textAngular.min.js',
        'app/app.js',
        'app/services/dataService.js',
        'app/services/authService.js',
        'app/services/authInterceptorService.js',
        'app/index/indexController.js',
        'app/home/homeController.js',
        'app/blogEntry/addOrUpdateBlogEntryController.js',
        'app/authHome/authHomeController.js',
        'app/signup/signupController.js',
        'app/login/loginController.js',
        'app/blogEntry/blogEntriesController.js',
        'app/blogEntryComments/addOrUpdateBlogEntryCommentController.js',
        'app/blogEntryComments/blogEntryCommentsController.js',
        'app/statistics/addOrUpdateStatisticController.js',
        'app/statistics/statisticsController.js',
        'app/myCastle/addOrUpdateMyCastleController.js',
        'app/myCastle/myCastleController.js',
        'app/myJourney/addOrUpdateMyJourneyController.js',
        'app/myJourney/myJourneyController.js',
        'app/myFamily/addOrUpdateMyFamilyController.js',
        'app/myFamily/myFamiliesController.js'
    ],
    angularbundle: 'Scripts/angular-bundle.min.js',

    //Bootstrap CSS and Fonts
    bootstrapcss: 'bower_components/bootstrap/dist/css/bootstrap.css',
    boostrapfonts: 'bower_components/bootstrap/dist/fonts/*.*',

    // SmartBlog CSS
    smartblogcss: 'Content/Main.SmartBlog.Modified.css',

    // Angular-Loading-Bar CSS
    angularloadingbarcss: 'bower_components/angular-loading-bar/loading-bar.min.css',

    // TextAngular CSS
    textangularcss: 'bower_components/textAngular/src/textAngular.css',

    // Font Awesome CSS
    fontawesomecss: 'bower_components/font-awesome/css/font-awesome.min.css',
    fontawesomefonts: 'bower_components/font-awesome/fonts/*.*',


    stylecss: 'Content/style.css',
    appcss: 'Content/site.css',
    fontsout: 'Content/dist/fonts',
    cssout: 'Content/dist/css'

}

// Synchronously delete the output script file(s)
gulp.task('clean-vendor-scripts', function (cb) {
    del([config.jquerybundle,
              config.bootstrapbundle,
              config.modernizrbundle,
              config.angularbundle], cb);
});

//Create a jquery bundled file
gulp.task('jquery-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.jquerysrc)
     .pipe(sourcemaps.init())
     .pipe(concat('jquery-bundle.min.js'))
     .pipe(sourcemaps.write('maps'))
     .pipe(gulp.dest('Scripts'));
});

//Create a bootstrap bundled file
gulp.task('bootstrap-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.bootstrapsrc)
     .pipe(sourcemaps.init())
     .pipe(concat('bootstrap-bundle.min.js'))
     .pipe(sourcemaps.write('maps'))
     .pipe(gulp.dest('Scripts'));
});

//Create a modernizr bundled file
gulp.task('modernizer', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.modernizrsrc)
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(concat('modernizer-min.js'))
        .pipe(sourcemaps.write('maps'))
        .pipe(gulp.dest('Scripts'));
});

//Create an angular bundled file
gulp.task('angular-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.angularsrc)
        .pipe(sourcemaps.init())
        //.pipe(uglify())
        .pipe(concat('angular-bundle.min.js'))
        .pipe(sourcemaps.write('maps'))
        .pipe(gulp.dest('Scripts'));
});

// Combine and the vendor files from bower into bundles (output to the Scripts folder)
gulp.task('vendor-scripts', ['jquery-bundle', 'bootstrap-bundle', 'modernizer', 'angular-bundle'], function () {

});

// Synchronously delete the output style files (css / fonts)
gulp.task('clean-styles', function (cb) {
    del([config.fontsout,
              config.cssout], cb);
});

gulp.task('css', ['clean-styles', 'bower-restore'], function () {
    return gulp.src([config.stylecss,
        config.bootstrapcss,
        config.appcss,
        config.smartblogcss,
        config.angularloadingbarcss,
        config.textangularcss,
        config.fontawesomecss
    ])
     .pipe(concat('app.css'))
     .pipe(gulp.dest(config.cssout))
     .pipe(minifyCSS())
     .pipe(concat('app.min.css'))
     .pipe(gulp.dest(config.cssout));
});

gulp.task('fonts', ['clean-styles', 'bower-restore'], function () {
    return gulp.src([
        config.boostrapfonts,
        config.fontawesomefonts
    ])
        .pipe(gulp.dest(config.fontsout));
});

// Combine and minify css files and output fonts
gulp.task('styles', ['css', 'fonts'], function () {

});

//Restore all bower packages
gulp.task('bower-restore', function () {
    return bower();
});

//Set a default tasks
gulp.task('default', ['vendor-scripts', 'styles'], function () {

});