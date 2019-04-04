var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/randomizer', function(req, res, next) {
  res.render('index', { title: 'MM5 Randomizer' });
});

module.exports = router;
