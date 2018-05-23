
/**
 * Dependencias do Gulp
 */
var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
var browserSync = require('browser-sync').create();

/*
    Cria um proxy para executar as tarefas indicadas
    assim como fazer o reload do browser
 */
gulp.task('browser-sync', function(){
    browserSync.init({
        proxy: 'localhost:5000'
    });
    gulp.watch('./Styles/**/*.css',['css']); 
    gulp.watch('./js/**/*.js',['js']); 
})

/**
 * Cria tarefa, nesse caso para fazer a copia dos .js de uma local
 * para outro.
 */
gulp.task('js', function () {

    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js',
        './js/site.js'
    ])
    .pipe(gulp.dest('wwwroot/js/'))
    .pipe(browserSync.stream());
});

/**
 * Cria tarefa, nesse caso para fazer a copia do css de um local
 * para outro, assim como, cria um bundle e minifica o conteúdo.
 */
gulp.task('css', function() {

    return gulp.src([
        './Styles/site.css',
        './node_modules/bootstrap/dist/css/bootstrap.css'   
    ])
    .pipe(concat('site.min.css'))
    .pipe(cssmin())
    .pipe(uncss({html:['Views/**/*.cshtml']}))
    .pipe(gulp.dest('wwwroot/css/'))
    .pipe(browserSync.stream());
});