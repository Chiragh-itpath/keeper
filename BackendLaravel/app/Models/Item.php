<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Item extends Model
{
    use HasFactory;

    use SoftDeletes;

    protected $fillable = [
        'id',
        'title',
        'description',
        'url',
        'type',
        'number',
        'to',
        'discussed_by',
        'tag_id',
        'created_by',
        'updated_by',
        'keep_id',
    ];

    protected $dates = [
        'created_at',
        'updated_at',
        'deleted_at',
    ];

    public function tag()
    {
        return $this->belongsTo(Tag::class);
    }

    public function keep()
    {
        return $this->belongsTo(Keep::class);
    }
}
