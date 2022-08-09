const Router = require('express');
const router = new Router();
const playerController = require('../controllers/playerController');

router.post('/', playerController.create);
router.get('/',playerController.getAll);

module.exports = router;