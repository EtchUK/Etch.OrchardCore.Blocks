const path = require('path');

module.exports = {
    entry: {
        editorjs: './Assets/Editor.js/js/index',
    },
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: 'babel-loader',
                },
            },
        ],
    },
    output: {
        filename: '[name]/admin.js',
        path: path.resolve(__dirname, './wwwroot/Scripts/'),
    },
};
