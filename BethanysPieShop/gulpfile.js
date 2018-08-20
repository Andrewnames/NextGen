var gulp = require("gulp"),
    fs = require("fs"),
    less = require("gulp-less");

gulp.task("less", function () {
    return gulp.src('wwwroot/Style/site.less')
        .pipe(less())
        .pipe(gulp.dest('wwwroot/css'));
});