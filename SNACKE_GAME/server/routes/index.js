const Router = require('express');
const router = new Router();
const playerRouter = require('./playerRouter');

router.use('/player', playerRouter);

module.exports = router
