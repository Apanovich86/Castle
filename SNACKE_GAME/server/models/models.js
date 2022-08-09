const sequelize = require('../db');
const {DataTypes} = require('sequelize');

const Player = sequelize.define('player', {
    id: {type: DataTypes.INTEGER, primaryKey: true, autoIncrement: true},
    name: {type: DataTypes.STRING, allowNull: false},
    score: {type: DataTypes.INTEGER}
})

module.exports = {Player}