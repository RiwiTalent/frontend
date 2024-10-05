const gulp = require('gulp');


//TASK
gulp.task('optimize', async () => {
    const imagemin = (await import('gulp-imagemin')).default;
    //we optimize images
    gulp.src('wwwroot/images/*')
        .pipe(imagemin())
        .pipe(gulp.dest('wwwroot/dist'))
});