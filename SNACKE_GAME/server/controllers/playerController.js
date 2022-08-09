const {Player} = require('../models/models');
const ApiError = require('../error/ApiError');
const db = require('../db');

class PlayerController {
    async create(req, res) {
        const {name, score} = req.body;
         const player = await Player.create({name, score});
         return res.json(player);
        res.json(player);
    }

    async getAll(req, res) {
        const {name, score} = req.body;
        const players = await Player.sequelize.query('SELECT * FROM players ORDER BY score DESC LIMIT 4');
         res.json(players);
    }
}

module.exports = new PlayerController();
