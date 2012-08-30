﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraLinq.Internals
{
    internal class CollectionElementsPicker<TSource>
    {
        private readonly IEnumerable<TSource> _source;
        private readonly Random _randomNumberGenerator;

        public CollectionElementsPicker(IEnumerable<TSource> source)
        {
            _source = source;
            _randomNumberGenerator = new Random();
        }

        public TSource PickRandomElement()
        {
            return PickRandomElement(_randomNumberGenerator);
        }

        public TSource PickRandomElement(Random randomNumberGenerator)
        {
            int itemCount = _source.Count();
            int randomIndex = randomNumberGenerator.Next(itemCount);

            return _source.ElementAt(randomIndex);
        }

        public IEnumerable<TSource> PickRandomElements(int randomElementsCount)
        {
            return PickRandomElements(randomElementsCount, _randomNumberGenerator);
        }

        public IEnumerable<TSource> PickRandomElements(int randomElementsCount, Random randomNumberGenerator)
        {
            var shuffler = new CollectionShuffler<TSource>(_source);
            var shuffledCollection = shuffler.ShuffleCollection(randomNumberGenerator);
            
            return shuffledCollection.Take(randomElementsCount);
        }
    }
}
