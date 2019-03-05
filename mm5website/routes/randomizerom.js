var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/randomizer/randomizerom', function(req, res, next) {
  res.render('randomizerom', { title: 'Randomize Mega Man 5' });
});

module.exports = router;
