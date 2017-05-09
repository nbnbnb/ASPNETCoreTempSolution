/// <binding AfterBuild='default' Clean='clean_scripts' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var del = require('del');

var paths = {
    scripts: "Scripts/**/*",

    npm_components: {
        angular: 'node_modules/@angular/**/*',
        axjs: 'node_modules/rxjs/**/*',
        corejs: 'node_modules/core-js/**/*',
        zonejs: 'node_modules/zone.js/**/*',
        systemjs: 'node_modules/systemjs/**/*',
        angularinmemorywebapi: 'node_modules/angular-in-memory-web-api/**/*'
    }
};

// 删除所有的 wwwroot/npm_components
// 然后将 paths.npm_components 拷贝到对应的 wwwroot/npm_components/** 下
gulp.task('components', function (cb) {
    del(['wwwroot/npm_components/**/*']).then(deletedPaths => {
        gulp.src(paths.npm_components.angular).pipe(gulp.dest('wwwroot/npm_components/@angular'));
        gulp.src(paths.npm_components.axjs).pipe(gulp.dest('wwwroot/npm_components/rxjs'));
        gulp.src(paths.npm_components.corejs).pipe(gulp.dest('wwwroot/npm_components/core-js'));
        gulp.src(paths.npm_components.zonejs).pipe(gulp.dest('wwwroot/npm_components/zone.js'));
        gulp.src(paths.npm_components.systemjs).pipe(gulp.dest('wwwroot/npm_components/systemjs'));
        gulp.src(paths.npm_components.angularinmemorywebapi).pipe(gulp.dest('wwwroot/npm_components/angular-in-memory-web-api'));
    });
});

// 清除 scripts 目录下的文件
gulp.task('clean_scripts', function (cb) {  // one
    del(['wwwroot/scripts/**/*']).then(paths => { cb(); });
});

gulp.task('clean_npm_components', function (cb) {  // one
    del(['wwwroot/npm_components/**/*']).then(paths => { cb(); });
});

// bower_components 在 .bowerrc 里面配置
gulp.task('clean_bower_components', function (cb) {  // one
    del(['wwwroot/bower_components/**/*']).then(paths => { cb(); });
});

// 清除 www/scripts 目录下的文件
// 然后将 paths.scripts 拷贝到 www/scripts
gulp.task('scripts', ['clean_scripts'], function (cb) {  // two
    gulp.src(paths.scripts).pipe(gulp.dest('wwwroot/scripts')).on('end', cb);
});

// 执行 scripts 任务
gulp.task('default', ['scripts']);