// Connections
var gulp = require('gulp');
var less = require('gulp-less');
var uglify = require('gulp-uglify');
var plumber = require('gulp-plumber');
var rename = require('gulp-rename');
const destCss = 'dest/css';
const destJs = 'dest/js';
const srcLess = 'less/**/*.less';
const srcMainLess = 'less/main.less';
const srcJs = 'js/**/*.less';

// Tasks
gulp.task('style', function () {
    gulp.src(srcMainLess)
        .pipe(plumber())
        .pipe(less())
        .pipe(gulp.dest(destCss));
});

gulp.task('script', function () {
    gulp.src(srcJs)
        .pipe(plumber())
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest(destJs));
});

gulp.task('watch', function () {
    gulp.watch(srcJs, ['script']);
    gulp.watch(srcLess, ['style']);
});

// Default task
gulp.task('default', ['style', 'script', 'watch']);